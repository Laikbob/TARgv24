namespace TARgv24_Tund_1;

public partial class TekstPage : ContentPage
{
    Label lbTekst;
    Editor editorText;
    HorizontalStackLayout hsl;
    Button btn;

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
        btn = new Button
        {
            Text = "Loe tekst"
        };
        btn.Clicked += Btn_Clicked;
        hsl = new HorizontalStackLayout
        {
            BackgroundColor = Color.FromRgb(120, 30, 50),
            Children = { lbTekst, editorText },
            HorizontalOptions = LayoutOptions.Center
        };

        Content = hsl;
    }

    private async void Btn_Clicked(object? sender, EventArgs e)
    {
        IEnumerable<Locale> locales = await TextToSpeech.Default.GetLocalesAsync();

        SpeechOptions options = new SpeechOptions()
        {
            Pitch = 1.5f,
            Volume = 0.75f,
            Locale = locales.FirstOrDefault(l => l.Language == "et-EE")
        };
        var text = editorText.Text;
        if (string.IsNullOrWhiteSpace(text))
        {
            await DisplayAlert("Viga", "Palun sisesta tekst", "OK");
            return;
        }
        try
        {
            await TextToSpeech.SpeakAsync(text, options);
        }
        catch (Exception ex)
        {
            await DisplayAlert("TTS viga", ex.Message, "OK");
        } 
}
    private void EditorText_TextChanged(object? sender, TextChangedEventArgs e)
    {
        lbTekst.Text = editorText.Text;
    }
}
