using Microsoft.Maui.Layouts;

namespace TARgv24_Tund_1;

public partial class Lumememm : ContentPage
{
    Frame bucket, head, body1, body2,eyes1, eyes2,nose, leftHand, rightHand;
    Random rnd = new Random();

    public Lumememm()
    {
        InitializeComponent();
        CreateLume();
        
    }
    void CreateLume()
    {
        bucket = new Frame
        {
            WidthRequest = 60,
            HeightRequest = 40,
            CornerRadius = 10,
            BackgroundColor = Colors.Blue,
            
        };
        AbsoluteLayout.SetLayoutBounds(bucket, new Rect(0.5, 0.12, 60, 40));
        AbsoluteLayout.SetLayoutFlags(bucket, AbsoluteLayoutFlags.PositionProportional);

        eyes1 = new Frame
        {
            WidthRequest = 12,  
            HeightRequest = 12,
            CornerRadius = 6,  
            BackgroundColor = Colors.Black
        };
        AbsoluteLayout.SetLayoutBounds(eyes1, new Rect(0.488, 0.23, 12, 12));  
        AbsoluteLayout.SetLayoutFlags(eyes1, AbsoluteLayoutFlags.PositionProportional);

        eyes2 = new Frame
        {
            WidthRequest = 12,
            HeightRequest = 12,
            CornerRadius = 6,
            BackgroundColor = Colors.Black
        };
        AbsoluteLayout.SetLayoutBounds(eyes2, new Rect(0.512, 0.23, 12, 12));  
        AbsoluteLayout.SetLayoutFlags(eyes2, AbsoluteLayoutFlags.PositionProportional);

        head = new Frame
        {
            WidthRequest = 80,
            HeightRequest = 80,
            CornerRadius = 40,
            BackgroundColor = Colors.White,
            BorderColor= Colors.White,
        };
        AbsoluteLayout.SetLayoutBounds(head, new Rect(0.5,0.25,80,80));
        AbsoluteLayout.SetLayoutFlags(head, AbsoluteLayoutFlags.PositionProportional);

        body1 = new Frame
        {
            WidthRequest= 110,
            HeightRequest= 110,
            CornerRadius = 55,
            BackgroundColor = Colors.White,
            BorderColor= Colors.White,
        };
        AbsoluteLayout.SetLayoutBounds(body1, new Rect(0.5,0.5,110,110));
        AbsoluteLayout.SetLayoutFlags(body1, AbsoluteLayoutFlags.PositionProportional);

        body2 = new Frame
        {
            WidthRequest= 140,
            HeightRequest= 140,
            CornerRadius= 75,
            BackgroundColor = Colors.White,
            BorderColor= Colors.White,
        };
        AbsoluteLayout.SetLayoutBounds(body2, new Rect(0.5, 0.8, 140, 140));
        AbsoluteLayout.SetLayoutFlags(body2, AbsoluteLayoutFlags.PositionProportional);

        nose = new Frame
        {
            WidthRequest = 20,     
            HeightRequest = 30,   
            BackgroundColor = Colors.Orange,
            Rotation = 45,         
            CornerRadius = 15,      
         
        };
        AbsoluteLayout.SetLayoutBounds(nose, new Rect(0.5, 0.3, 20, 30));  
        AbsoluteLayout.SetLayoutFlags(nose, AbsoluteLayoutFlags.PositionProportional);

        leftHand = new Frame
        {
            WidthRequest = 60,
            HeightRequest = 10,
            CornerRadius = 5,
            BackgroundColor = Colors.Brown,
            Rotation = -30 
        };
        AbsoluteLayout.SetLayoutBounds(leftHand, new Rect(0.45, 0.48, 60, 10));
        AbsoluteLayout.SetLayoutFlags(leftHand, AbsoluteLayoutFlags.PositionProportional);

        rightHand = new Frame
        {
            WidthRequest = 60,
            HeightRequest = 10,
            CornerRadius = 5,
            BackgroundColor = Colors.Brown,
            Rotation = 30
        };
        AbsoluteLayout.SetLayoutBounds(rightHand, new Rect(0.55, 0.48, 60, 10));
        AbsoluteLayout.SetLayoutFlags(rightHand, AbsoluteLayoutFlags.PositionProportional);


        snowmanLayout.Children.Add(bucket);
        snowmanLayout.Children.Add(head);
        snowmanLayout.Children.Add(body1);
        snowmanLayout.Children.Add(body2);
        snowmanLayout.Children.Add(eyes1);
        snowmanLayout.Children.Add(eyes2);
        snowmanLayout.Children.Add(nose);
        snowmanLayout.Children.Add(leftHand);
        snowmanLayout.Children.Add(rightHand);

    }
    private void buNäita_Clicked(object sender, EventArgs e)
    {
        snowmanLayout.IsVisible = true;
    }
    private void buPeida_Clicked(object sender, EventArgs e)
    {
        snowmanLayout.IsVisible = false;
    }
    private void buVärv_Clicked(object sender, EventArgs e)
    {
        Color newColor1 = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        head.BackgroundColor = newColor1;
        Color newColor2 = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        body1.BackgroundColor = newColor2;
        Color newColor3 = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        body2.BackgroundColor = newColor3;
    }
    private async void buTantsi_Clicked(object sender, EventArgs e)
    {
        // Поднять руки
        await Task.WhenAll(
            leftHand.RotateTo(-80, 500),  // левая вверх
            rightHand.RotateTo(80, 500)   // правая вверх
        );

        // Опустить руки
        await Task.WhenAll(
            leftHand.RotateTo(-30, 500),
            rightHand.RotateTo(30, 500)
        );
    } 
    

}