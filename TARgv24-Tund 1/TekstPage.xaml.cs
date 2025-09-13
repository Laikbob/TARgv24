namespace TARgv24_Tund_1;

public partial class TekstPage : ContentPage
{
    Label lbTekst;
    Editor editorText;
    HorizontalStackLayout hsl;

    public TekstPage()
    {
        lbTekst = new Label
        {
            Text = "Tekst: ",
            FontSize = 20,
            TextColor = Colors.Black,
            FontFamily = "Charito"
        };

        editorText = new Editor
        {
            FontSize = 20,
            BackgroundColor = Color.FromRgb(200, 200, 100),
            FontFamily = "Charito",
            AutoSize = EditorAutoSizeOption.TextChanges,
            Placeholder = "Siia tuleb tekst",
            PlaceholderColor = Colors.Gray,
            FontAttributes = FontAttributes.Italic
        };
        editorText.TextChanged += EditorText_TextChanged;

        hsl = new HorizontalStackLayout
        {
            BackgroundColor = Color.FromRgb(120, 30, 50),
            Children = { lbTekst, editorText },
            HorizontalOptions = LayoutOptions.Center
        };

        Content = hsl;
    }

    private void EditorText_TextChanged(object? sender, TextChangedEventArgs e)
    {
        lbTekst.Text = editorText.Text;
    }
}
