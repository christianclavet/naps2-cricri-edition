using Eto.Drawing;
using Eto.Forms;

namespace NAPS2.EtoForms.Layout;

public class LayoutRow : LayoutLine<LayoutRow, LayoutColumn>
{
    public LayoutRow(LayoutElement[] children)
    {
        Children = children;
    }

    public LayoutRow(LayoutRow original, Padding? padding = null, int? spacing = null, bool? yScale = null,
        bool? aligned = null)
    {
        Children = original.Children;
        Padding = padding ?? original.Padding;
        Spacing = spacing ?? original.Spacing;
        YScale = yScale ?? original.YScale;
        Aligned = aligned ?? original.Aligned;
    }

    private Padding? Padding { get; }

    public override void AddTo(DynamicLayout layout)
    {
        if (!Aligned)
        {
            layout.BeginVertical();
        }
        layout.BeginHorizontal(yscale: YScale);
        foreach (var child in Children)
        {
            child.AddTo(layout);
        }
        layout.EndHorizontal();
        if (!Aligned)
        {
            layout.EndVertical();
        }
    }

    protected override PointF UpdatePosition(PointF position, float delta)
    {
        position.X += delta;
        return position;
    }

    protected override SizeF UpdateTotalSize(SizeF size, SizeF childSize, int spacing)
    {
        size.Width += childSize.Width + spacing;
        size.Height = Math.Max(size.Height, childSize.Height);
        return size;
    }

    protected internal override bool DoesChildScale(LayoutElement child) => child.XScale;

    protected override float GetBreadth(SizeF size) => size.Height;
    protected override float GetLength(SizeF size) => size.Width;
    protected override SizeF GetSize(float length, float breadth) => new(length, breadth);
}