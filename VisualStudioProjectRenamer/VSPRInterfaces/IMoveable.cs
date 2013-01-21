namespace VSPRInterfaces
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// By default, forms with BorderStyle.None are not moveable. 
    /// This interface is a workaround, to make forms with no border, moveable.
    /// See: http://social.msdn.microsoft.com/forums/en-US/csharpgeneral/thread/44530727-42ec-461b-9bea-36026a449f05
    /// </summary>
    public interface IMoveable
    {
        Point MouseOffset { get;}
        void Header_MouseEnter(object sender, EventArgs e);
        void Header_MouseLeave(object sender, EventArgs e);
        void MoveFormOn_MouseMove(object sender, MouseEventArgs e);
        void SetOffSetOn_MouseDown(object sender, MouseEventArgs e);
    }
}