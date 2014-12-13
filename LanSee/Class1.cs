using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LanSee
{
    class Class1
    {
    }
    class ActiveHook
    {
        /*****************************************
         * Created By: Jickie 阿文
         * Created: 2009/10/29
         * **************************************/

        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_CHAR = 0x0102;

        public const int SWP_NOSIZE = 0x0001;
        public const int SWP_NOMOVE = 0x0002;
        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_NOREDRAW = 0x0008;
        public const int SWP_NOACTIVATE = 0x0010;
        public const int SWP_FRAMECHANGED = 0x0020;  /* The frame changed: send WM_NCCALCSIZE */
        public const int SWP_SHOWWINDOW = 0x0040;
        public const int SWP_HIDEWINDOW = 0x0080;
        public const int SWP_NOCOPYBITS = 0x0100;
        public const int SWP_NOOWNERZORDER = 0x0200;  /* Don't do owner Z ordering */
        public const int SWP_NOSENDCHANGING = 0x0400;  /* Don't send WM_WINDOWPOSCHANGING */

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        public const uint WS_OVERLAPPED = WS_BORDER | WS_CAPTION;
        public const uint WS_CLIPSIBLINGS = 0x04000000;
        public const uint WS_CLIPCHILDREN = 0x02000000;
        public const uint WS_CAPTION = 0x00C00000;     /* WS_BORDER | WS_DLGFRAME  */
        public const uint WS_BORDER = 0x00800000;
        public const uint WS_DLGFRAME = 0x00400000;
        public const uint WS_VSCROLL = 0x00200000;
        public const uint WS_HSCROLL = 0x00100000;
        public const uint WS_SYSMENU = 0x00080000;
        public const uint WS_THICKFRAME = 0x00040000;
        public const uint WS_MAXIMIZEBOX = 0x00020000;
        public const uint WS_MINIMIZEBOX = 0x00010000;
        public const uint WS_SIZEBOX = WS_THICKFRAME;
        public const uint WS_POPUP = 0x80000000;
        public const uint WS_CHILD = 0x40000000;
        public const uint WS_VISIBLE = 0x10000000;
        public const uint WS_DISABLED = 0x08000000;

        public const uint WS_EX_DLGMODALFRAME = 0x00000001;
        public const uint WS_EX_TOPMOST = 0x00000008;
        public const uint WS_EX_TOOLWINDOW = 0x00000080;
        public const uint WS_EX_WINDOWEDGE = 0x00000100;
        public const uint WS_EX_CLIENTEDGE = 0x00000200;

        public const uint WS_EX_CONTEXTHELP = 0x00000400;
        public const uint WS_EX_STATICEDGE = 0x00020000;
        public const uint WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);

        public const int GWL_STYLE = (-16);
        public const int GWL_EXSTYLE = (-20);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr32(IntPtr hWnd, int nIndex, int dwNewLong);


        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        public const int WH_KEYBOARD = 2;
        public const int WH_MOUSE = 7;
        public const int WH_KEYBOARD_LL = 13;
        public const int WH_MOUSE_LL = 14;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
    }


    public class Hook
    {
        public delegate void KeyboardDelegate(KeyEventArgs e);
        public KeyboardDelegate OnKeyDown;
        int m_hHook = 0;
        ActiveHook.HookProc m_HookCallback;

        public void SetHook(bool enable)
        {
            if (enable && m_hHook == 0)
            {
                m_HookCallback = new ActiveHook.HookProc(HookCallbackProc);
                Module module = Assembly.GetExecutingAssembly().GetModules()[0];
                m_hHook = ActiveHook.SetWindowsHookEx(ActiveHook.WH_KEYBOARD_LL, m_HookCallback, Marshal.GetHINSTANCE(module), 0);
                return;
            }

            if (enable == false && m_hHook != 0)
            {
                ActiveHook.UnhookWindowsHookEx(m_hHook);
                m_hHook = 0;
            }
        }
        int HookCallbackProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return ActiveHook.CallNextHookEx(m_hHook, nCode, wParam, lParam);
            }
            else
            {
                ActiveHook.KeyboardHookStruct hookstruct = (ActiveHook.KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(ActiveHook.KeyboardHookStruct));

                if (OnKeyDown != null && wParam.ToInt32() == ActiveHook.WM_KEYDOWN)
                {
                    Keys key = (Keys)hookstruct.vkCode;
                    if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                        key |= Keys.Shift;
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                        key |= Keys.Control;
                    if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
                        key |= Keys.Alt;

                    KeyEventArgs e = new KeyEventArgs(key);
                    e.Handled = false;
                    OnKeyDown(e);
                    if (e.Handled)
                        return 1;
                }
                int result = 0;
                if (m_hHook != 0)
                    result = ActiveHook.CallNextHookEx(m_hHook, nCode, wParam, lParam);
                return result;
            }
        }

    }
}
