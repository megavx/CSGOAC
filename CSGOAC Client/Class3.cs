
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

class SteamTheme : ThemeContainer153
{

    public SteamTheme()
    {
        ForeColor = Color.FromArgb(226, 226, 226);
        Font = new Font("Segoe UI", 7);
    }


    protected override void ColorHook()
    {
    }

    protected override void PaintHook()
    {
        DrawGradient(Color.FromArgb(25, 54, 82), Color.FromArgb(29, 30, 31), ClientRectangle, 43);
        DrawGradient(Color.FromArgb(25, 54, 82), Color.Transparent, ClientRectangle, -100);
        G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), new Rectangle(1, 1, Width - 2, Height - 2));
        DrawGradient(Color.FromArgb(30, 36, 44), Color.FromArgb(38, 38, 38), new Rectangle(1, 1, Width - 2, 35), 90);
        DrawText(new SolidBrush(Color.FromArgb(195, 193, 191)), HorizontalAlignment.Left, 7, 2);
    }
}

class SteamButton : ThemeControl153
{

    private _Options O;
    [Flags()]
    public enum _Options
    {
        _true,
        _false
    }
    [Category("Activated")]
    public _Options Activated
    {
        get { return O; }
        set { O = value; }
    }
    public SteamButton()
    {
        this.Font = new Font("Verdana", 7.25f);

    }


    protected override void ColorHook()
    {
    }
    protected override void PaintHook()
    {
        this.G.Clear(Color.FromArgb(38, 38, 38));
        SteamButton._Options o = this.O;
        if (o == SteamButton._Options._true)
        {
            switch (this.State)
            {
                case MouseState.None:
                    {
                        base.DrawGradient(Color.FromArgb(79, 79, 79), Color.FromArgb(58, 58, 58), base.ClientRectangle, 90f);
                        break;
                    }
                case MouseState.Over:
                    {
                        base.DrawGradient(Color.FromArgb(105, 105, 105), Color.FromArgb(61, 61, 61), base.ClientRectangle, 90f);
                        break;
                    }
                case MouseState.Down:
                    {
                        base.DrawGradient(Color.FromArgb(39, 39, 39), Color.FromArgb(57, 57, 57), base.ClientRectangle, 90f);
                        break;
                    }
            }
            base.DrawText(new SolidBrush(Color.FromArgb(195, 193, 191)), this.Text.ToUpper(), HorizontalAlignment.Left, 4, 0);
        }
        else if (o == SteamButton._Options._false)
        {
            switch (this.State)
            {
                case MouseState.None:
                    {
                        base.DrawGradient(Color.FromArgb(44, 44, 44), Color.FromArgb(44, 44, 44), base.ClientRectangle, 90f);
                        break;
                    }
                case MouseState.Over:
                    {
                        base.DrawGradient(Color.FromArgb(44, 44, 44), Color.FromArgb(44, 44, 44), base.ClientRectangle, 90f);
                        break;
                    }
                case MouseState.Down:
                    {
                        base.DrawGradient(Color.FromArgb(44, 44, 44), Color.FromArgb(44, 44, 44), base.ClientRectangle, 90f);
                        break;
                    }
            }
            base.DrawText(new SolidBrush(Color.FromArgb(115, 115, 115)), this.Text.ToUpper(), HorizontalAlignment.Left, 4, 0);
        }
    }
}
    class SteamSeparator : ThemeControl153
{


    protected override void ColorHook()
    {
    }

    protected override void PaintHook()
    {
        G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), ClientRectangle);
        DrawGradient(Color.FromArgb(107, 104, 101), Color.FromArgb(74, 72, 70), new Rectangle(0, Height / 2, Width, 1), 45);
    }
}
class SteamTextBox : ThemeControl153
{
    private TextBox withEventsField_txtbox = new TextBox();
    public TextBox txtbox
    {
        get { return withEventsField_txtbox; }
        set
        {
            EventHandler eventHandler = (object a0, EventArgs a1) => this.TextChngTxtBox();
            if (withEventsField_txtbox != null)
            {
                withEventsField_txtbox.TextChanged -= eventHandler;
            }
            withEventsField_txtbox = value;
            if (withEventsField_txtbox != null)
            {
                withEventsField_txtbox.TextChanged += eventHandler;
            }
        }

    }
    private bool _PassMask;
    public bool UsePasswordMask
    {
        get { return _PassMask; }
        set
        {
            _PassMask = value;
            Invalidate();
        }
    }
    private int _maxchars;
    public int MaxCharacters
    {
        get { return _maxchars; }
        set { _maxchars = value; }
    }

    public SteamTextBox()
    {
        base.TextChanged += new EventHandler((object a0, EventArgs a1) => this.TextChng());
        this.txtbox = new TextBox()
        {
            TextAlign = HorizontalAlignment.Left,
            BorderStyle = BorderStyle.None,
            Location = new Point(4, 4),
            Font = new Font("Segoe UI", 8f)
        };
        base.Controls.Add(this.txtbox);
        this.Text = "";
        this.txtbox.Text = "";
        base.Size = new Size(135, 22);
        base.Transparent = true;
        this.BackColor = Color.Transparent;
    }


    Pen P1;
    protected override void ColorHook()
    {
    }

    protected override void PaintHook()
    {
        G.Clear(Color.FromArgb(38, 38, 38));
        switch (UsePasswordMask)
        {
            case true:
                txtbox.UseSystemPasswordChar = true;
                break;
            case false:
                txtbox.UseSystemPasswordChar = false;
                break;
        }
        Size = new Size(Width, 22);
        txtbox.BackColor = Color.FromArgb(38, 38, 38);
        txtbox.ForeColor = Color.FromArgb(195, 193, 191);
        txtbox.Font = Font;
        txtbox.Size = new Size(Width - 10, txtbox.Height - 10);
        txtbox.MaxLength = MaxCharacters;
        DrawBorders(new Pen(new SolidBrush(Color.FromArgb(137, 137, 137))));
        DrawCorners(BackColor);
    }
    public void TextChngTxtBox()
    {
        Text = txtbox.Text;
    }
    public void TextChng()
    {
        txtbox.Text = Text;
    }
}

[DefaultEvent("CheckedChanged")]
class SteamCheckBox : Control
{

    #region " Variables"

    private int W;
    private int H;
    private MouseState State = MouseState.None;
    private _Options O;

    private bool _Checked;
    #endregion

    #region " Properties"
    protected override void OnTextChanged(System.EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }

    public bool Checked
    {
        get { return _Checked; }
        set
        {
            _Checked = value;
            Invalidate();
        }
    }

    public event CheckedChangedEventHandler CheckedChanged;
    public delegate void CheckedChangedEventHandler(object sender);
    protected override void OnClick(System.EventArgs e)
    {
        _Checked = !_Checked;
        if (CheckedChanged != null)
        {
            CheckedChanged(this);
        }
        base.OnClick(e);
    }

    [Flags()]
    public enum _Options
    {
        Style1,
        Style2
    }

    [Category("Options")]
    public _Options Options
    {
        get { return O; }
        set { O = value; }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Height = 22;
    }

    #region " Colors"

    [Category("Colors")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set { _BaseColor = value; }
    }

    [Category("Colors")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set { _BorderColor = value; }
    }

    #endregion

    #region " Mouse States"

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        State = MouseState.Down;
        Invalidate();
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = MouseState.Over;
        Invalidate();
    }
    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = MouseState.Over;
        Invalidate();
    }
    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        State = MouseState.None;
        Invalidate();
    }

    #endregion

    #endregion

    #region " Colors"
    #region " Variables"
    internal Graphics G;
    internal Bitmap B;
    internal Color _FlatColor = Color.FromArgb(103, 103, 103);
    internal StringFormat NearSF = new StringFormat
    {
        Alignment = StringAlignment.Near,
        LineAlignment = StringAlignment.Near
    };
    internal StringFormat CenterSF = new StringFormat
    {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center
        #endregion
    };
    private Color _BaseColor = Color.FromArgb(38, 38, 38);
    private Color _BorderColor = Color.FromArgb(103, 103, 103);
    private Color _TextColor = Color.FromArgb(226, 226, 226);

    private Color checkcolor = Color.FromArgb(226, 226, 226);
    #endregion

    public SteamCheckBox()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
        DoubleBuffered = true;
        BackColor = Color.FromArgb(38, 38, 38);
        Cursor = Cursors.Hand;
        Font = new Font("Segoe UI", 8);
        Size = new Size(112, 22);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        B = new Bitmap(Width, Height);
        G = Graphics.FromImage(B);
        W = Width - 1;
        H = Height - 1;

        Rectangle Base = new Rectangle(0, 2, Height - 5, Height - 5);

        var _with1 = G;
        _with1.SmoothingMode = SmoothingMode.HighQuality;
        _with1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        _with1.Clear(BackColor);

        _with1.FillRectangle(new SolidBrush(_BaseColor), Base);

        _with1.DrawRectangle(new Pen(_BorderColor), Base);

        if (Checked)
        {
            _with1.DrawString("", new Font("Segoe UI Symbol", 10), new SolidBrush(checkcolor), new Rectangle(4, 6, H - 9, H - 10), CenterSF);
        }

        _with1.DrawString(Text, Font, new SolidBrush(_TextColor), new Rectangle(25, 4, W, H), NearSF);


        base.OnPaint(e);
        G.Dispose();
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        e.Graphics.DrawImageUnscaled(B, 0, 0);
        B.Dispose();
    }
}

class SteamClose : Control
{

    #region " Declarations "
    #endregion
    private MouseState _State;

    #region " Mouse States "
    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        _State = MouseState.Over;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _State = MouseState.None;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        _State = MouseState.Down;
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        _State = MouseState.Over;
        Invalidate();
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        Environment.Exit(0);
    }
    #endregion

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = new Size(12, 12);
    }

    public SteamClose()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        Size = new Size(12, 12);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics G = e.Graphics;
        this.BackColor = Color.Transparent;
        StringFormat _StringF = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        G.DrawString("✕", new Font("Segoe UI Symbol", 10.03f, FontStyle.Bold), new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(175, 175, 175), Color.FromArgb(175, 175, 175)), new RectangleF(0f, 0f, (float)base.Width, (float)base.Height), _StringF);
        MouseState mouseState = this._State;
        if (mouseState == MouseState.Over)
        {
            G.DrawString("✕", new Font("Segoe UI Symbol", 10.03f, FontStyle.Bold), new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(226, 226, 226), Color.FromArgb(226, 226, 226)), new RectangleF(0f, 0f, (float)base.Width, (float)base.Height), _StringF);
        }
        else if (mouseState == MouseState.Down)
        {
            G.DrawString("✕", new Font("Segoe UI Symbol", 10.03f, FontStyle.Bold), new SolidBrush(Color.FromArgb(40, Color.Black)), new RectangleF(0f, 0f, (float)base.Width, (float)base.Height), _StringF);
        }
    }

}

class SteamMinimize : Control
{

    #region " Declarations "
    #endregion
    private MouseState _State;

    #region " Mouse States "
    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        _State = MouseState.Over;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _State = MouseState.None;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        _State = MouseState.Down;
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        _State = MouseState.Over;
        Invalidate();
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        base.FindForm().WindowState = FormWindowState.Minimized;
    }
    #endregion

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = new Size(12, 12);
    }

    public SteamMinimize()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        Size = new Size(12, 12);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics G = e.Graphics;
        this.BackColor = Color.Transparent;
        StringFormat _StringF = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        G.DrawString("0", new Font("Marlett", 11f), new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(175, 175, 175), Color.FromArgb(175, 175, 175)), new RectangleF(0f, 0f, (float)base.Width, (float)base.Height), _StringF);
        MouseState mouseState = this._State;
        if (mouseState == MouseState.Over)
        {
            G.DrawString("0", new Font("Marlett", 11f), new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(226, 226, 226), Color.FromArgb(175, 175, 175)), new RectangleF(0f, 0f, (float)base.Width, (float)base.Height), _StringF);
        }
        else if (mouseState == MouseState.Down)
        {
            G.DrawString("0", new Font("Marlett", 11f), new SolidBrush(Color.FromArgb(40, Color.Black)), new RectangleF(0f, 0f, (float)base.Width, (float)base.Height), _StringF);
        }
    }
}

