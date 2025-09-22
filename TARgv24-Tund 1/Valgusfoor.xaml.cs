using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace TARgv24_Tund_1;

public partial class Valgusfoor : ContentPage
{
    readonly Color[] activeColors = { Colors.Red, Colors.Yellow, Colors.Green };
    readonly Color inactiveColor = Colors.Gray;
    readonly string[] messages = { "Seisa!", "Valmista!", "Sõida!" };
    
    //список круг
    List<Frame> circles = new List<Frame>();
    bool isOn = false;

    private CancellationTokenSource? nightModeCts;
    

    public Valgusfoor()
    {
        InitializeComponent();
        CreateCircles();
    }

    void CreateCircles()
    {
        for (int i = 0; i < 3; i++)
        {
            Frame circle = new Frame
            {
                WidthRequest = 80,
                HeightRequest = 80,
                CornerRadius = 40,
                BackgroundColor = inactiveColor,
                BorderColor = Colors.Black,
                HasShadow = false,
                HorizontalOptions = LayoutOptions.Center,
                
            };

            int idx = i;
            circle.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await CircleTapped(idx))
            });

            circles.Add(circle);
            lightContainer.Children.Add(circle);
        }
    }
    private async Task CircleTapped(int idx)
    {
        if (!isOn)
        {
            statusLabel.Text = "Lülita esmalt foor sisse!";
            return;
        }

        // Сбрасываем все круги
        foreach (var c in circles)
            c.BackgroundColor = inactiveColor;

        // Включаем выбранный цвет
        circles[idx].BackgroundColor = activeColors[idx];
        statusLabel.Text = messages[idx];

    }
    private void butSisse_Clicked(object sender, EventArgs e)
    {
        isOn = true;
        statusLabel.Text = "Vali valgus";
        nightModeCts?.Cancel();
        foreach (var c in circles)
            c.BackgroundColor = inactiveColor;
    }

    private void butVälja_Clicked(object sender, EventArgs e)
    {
        isOn = false;
        statusLabel.Text = "Lülita esmalt foor sisse";
        nightModeCts?.Cancel();
        foreach (var c in circles)
            c.BackgroundColor = inactiveColor;
    }

    private void butÖö_Clicked(object sender, EventArgs e)
    {
        if (!isOn)
        {
            statusLabel.Text = "Lülita esmalt foor sisse!";
            return;
        }

        statusLabel.Text = "Öö režiim (vilgub kollane)";

        // Останавливаем предыдущий режим
        nightModeCts?.Cancel();
        nightModeCts = new CancellationTokenSource();
        var token = nightModeCts.Token;

        // Сбрасываем все круги
        foreach (var c in circles)
            c.BackgroundColor = inactiveColor;

        // Запускаем мигание жёлтым
        _ = Task.Run(async () =>
        {
            bool on = false;
            while (!token.IsCancellationRequested)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    circles[1].BackgroundColor = on ? Colors.Yellow : inactiveColor;
                });
                on = !on;
                await Task.Delay(700, token); // задержка
            }
        }, token);
    }

}
