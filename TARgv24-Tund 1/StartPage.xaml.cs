    namespace TARgv24_Tund_1;

public partial class StartPage : ContentPage
{
    public List<ContentPage> lehed = new List<ContentPage>() { new TekstPage(), new FigurePage(), new TimerPage(), new Valgusfoor(), new DateTimePage(), new Lumememm()  };
    public List<string> tekstid = new List<string>() { "Tee lahti tekstiga", "Tee lahti Figure tekst", "Käivitada kella", " 🚦Valgusfoor", " 🕰Kella aeg" , "⛄Lumememm" };
    ScrollView sv;
    VerticalStackLayout vsl;

    public StartPage()
    {
        Title = "Avaleht";
        vsl = new VerticalStackLayout { BackgroundColor = Color.FromRgb(120, 30, 50) };

        for (int i = 0; i < lehed.Count; i++)
        {
            Button nupp = new Button
            {
                Text = tekstid[i],
                FontSize = 20,
                BackgroundColor = Color.FromRgb(200, 200, 100),
                TextColor = Colors.Black,
                CornerRadius = 20,
                FontFamily = "Charito",
                ClassId = i.ToString(), // Сохраняем индекс здесь
            };

            nupp.Clicked += Nupp_Clicked;
            vsl.Add(nupp);
        }

        sv = new ScrollView { Content = vsl };
        Content = sv;
    }

    private async void Nupp_Clicked(object sender, EventArgs e)
    {
        Button nupp = (Button)sender;
        int index = int.Parse(nupp.ClassId);

        // Навигация к нужной странице
        await Navigation.PushAsync(lehed[index]);
    }
}
