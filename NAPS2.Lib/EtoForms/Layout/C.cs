using System.Windows.Input;
using Eto.Drawing;
using Eto.Forms;
using NAPS2.Scan;

namespace NAPS2.EtoForms.Layout;

public static class C
{
    /// <summary>
    /// Creates a label with wrapping disabled. For WinForms support, all labels must not wrap.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static Label NoWrap(string text) =>
        new Label { Text = text, Wrap = WrapMode.None };

    /// <summary>
    /// Creates a link button with the given URL as both text and click action.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static LinkButton UrlLink(string url)
    {
        void OnClick() => Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        return new LinkButton
        {
            Text = url,
            Command = new ActionCommand(OnClick)
        };
    }

    /// <summary>
    /// Creates a link button with the specified text.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static LinkButton Link(string text)
    {
        return new LinkButton { Text = text };
    }

    /// <summary>
    /// Creates a link button with the specified text and action.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="onClick"></param>
    /// <returns></returns>
    public static LinkButton Link(string text, Action onClick)
    {
        return new LinkButton
        {
            Text = text,
            Command = new ActionCommand(onClick)
        };
    }

    /// <summary>
    /// Creates a button with the specified text.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static Button Button(string text) => new() { Text = text };

    /// <summary>
    /// Creates a button with the specified text and action.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="onClick"></param>
    /// <returns></returns>
    public static Button Button(string text, Action onClick) =>
        Button(text, new ActionCommand(onClick));

    /// <summary>
    /// Creates a button with the specified text and command.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    public static Button Button(string text, ICommand command) =>
        new Button
        {
            Text = text,
            Command = command
        };

    public static Button Button(Command command) =>
        Button(command.MenuText, command);

    public static Button Button(Command command, ButtonImagePosition imagePosition)
    {
        var button = Button(command);
        button.Image = command.Image;
        button.ImagePosition = imagePosition;
        EtoPlatform.Current.ConfigureImageButton(button);
        return button;
    }

    public static Button Button(Command command, Image image, ButtonImagePosition imagePosition = default)
    {
        var button = Button(command);
        button.Image = image;
        button.ImagePosition = imagePosition;
        EtoPlatform.Current.ConfigureImageButton(button);
        return button;
    }

    // TODO: Clean up button overloads
    public static Button ImageButton(Command command) =>
        new Button
        {
            Text = command.MenuText,
            Command = command,
            Image = command.Image
        };

    /// <summary>
    /// Creates a null placeholder for Eto layouts that absorbs scaling.
    /// </summary>
    /// <returns></returns>
    public static ControlWithLayoutAttributes Filler() =>
        new ControlWithLayoutAttributes(null).XScale().YScale();

    /// <summary>
    /// Creates a null placeholder for Eto layouts.
    /// </summary>
    /// <returns></returns>
    public static ControlWithLayoutAttributes Spacer() =>
        new ControlWithLayoutAttributes(null);

    /// <summary>
    /// Creates an label of default height to be used as a visual paragraph separator.
    /// </summary>
    /// <returns></returns>
    public static LayoutElement TextSpace() => NoWrap(" ");

    public static Label Label(string text) => new() { Text = text };

    public static DropDown EnumDropDown<T>(params T[] values) where T : Enum
    {
        var combo = new DropDown();
        foreach (var item in values)
        {
            combo.Items.Add(new ListItem
            {
                Key = item.ToString(),
                Text = item.Description()
            });
        }
        return combo;
    }

    public static DropDown EnumDropDown<T>() where T : Enum
    {
        return EnumDropDown<T>(x => x.Description());
    }

    public static DropDown EnumDropDown<T>(Func<T, string> format) where T : Enum
    {
        var combo = new DropDown();
        foreach (var item in Enum.GetValues(typeof(T)))
        {
            combo.Items.Add(new ListItem
            {
                Key = item.ToString(),
                Text = format((T) item)
            });
        }
        return combo;
    }

    public static CheckBox CheckBox(string text) => new() { Text = text };

    public static Button CancelButton(Dialog dialog, string? text = null) =>
        DialogButton(dialog, text ?? UiStrings.Cancel, isAbort: true);

    public static Button OkButton(Dialog dialog, Action? beforeClose = null, string? text = null) =>
        DialogButton(dialog, text ?? UiStrings.OK, isDefault: true, beforeClose: beforeClose);

    public static Button DialogButton(Dialog dialog, string text, bool isDefault = false, bool isAbort = false,
        Action? beforeClose = null)
    {
        var button = Button(text, () =>
        {
            beforeClose?.Invoke();
            dialog.Close();
        });
        if (isDefault)
        {
            dialog.DefaultButton = button;
        }
        if (isAbort)
        {
            dialog.AbortButton = button;
        }
        return button;
    }

    private static IEnumerable<Control> GetAllControls(Control control)
    {
        if (control is not Container container) return Enumerable.Repeat(control, 1);
        return container.Controls.SelectMany(GetAllControls).Append(control);
    }

    public static LayoutElement None()
    {
        return new SkipLayoutElement();
    }
}