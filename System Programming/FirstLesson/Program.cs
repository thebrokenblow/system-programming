using System.Runtime.InteropServices;

MessageBox(IntPtr.Zero, "Заголовок", "Основной текст!", 0);

[DllImport("user32.dll")] 
static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
