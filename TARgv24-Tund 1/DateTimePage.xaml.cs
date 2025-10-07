namespace TARgv24_Tund_1;
using Microsoft.Maui.Layouts;

public partial class DateTimePage : ContentPage
{
	Label mis_on_valitud;
	DatePicker datePicker;
	TimePicker timePicker;
	Picker picker;
	Slider slider;
	Stepper stepper;
	AbsoluteLayout al;
	public DateTimePage()
	{
		mis_on_valitud = new Label
		{
			Text = "Siin kuvatakse valitud kuupäev või kellaaeg",
			FontSize = 21,
			TextColor = Colors.Red
			
		};
		datePicker = new DatePicker
		{
			FontSize = 20,
			BackgroundColor = Color.FromRgb(200, 200, 100),
			TextColor = Colors.Black,
			MinimumDate = DateTime.Now.AddDays(-7),
			MaximumDate = new DateTime(2100, 12, 31),
			Date = DateTime.Now,
			Format="D"
		};
		datePicker.DateSelected += Kuupäeva_valimine;

		timePicker = new TimePicker
		{
			FontSize = 20,
			BackgroundColor = Color.FromRgb(200, 200, 100),
			TextColor = Colors.Black,
			Time = new TimeSpan(12, 0, 0),
			Format = "T"
		};
		timePicker.PropertyChanged += (s, e) =>
		{
			if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
			{
				mis_on_valitud.Text = $"Valisite kellaa: {timePicker.Time}";
			}
		};

		picker = new Picker
		{
			Title = "Vali üks",
			FontSize= 20,
			BackgroundColor = Color.FromRgb(200,200, 100),
			TextColor = Colors.Black,
			ItemsSource = new List<string> { "Teade", "Jah/Ei teade", "Valik","Vaba vastus"}
		};
		//picker.Items.Add("Kuus");
		picker.SelectedIndexChanged += (s, e) =>
		{
            if (picker.SelectedIndex != -1 )
            {
                mis_on_valitud.Text = $"Valisite: {picker.Items[picker.SelectedIndex]}";
				if (picker.SelectedIndex == 0)
				{
					DisplayAlert("Teade", "Meil on hea uudis", "Selge");
				}
				else if (picker.SelectedIndex == 1)
				{
					DisplayAlert("Küsimus", "Kas soovite jäykata?", "Jah", "Ei");
				}
				else if (picker.SelectedIndex == 2)
				{ 
					
				}
            }
        };
		slider = new Slider
		{
			Minimum = 0,
			Maximum = 100,
			Value = 100,
			BackgroundColor= Color.FromRgb(200,200,100),
			ThumbColor = Colors.Red,
			MinimumTrackColor = Colors.Green,
			MaximumTrackColor = Colors.Blue,
		};
		slider.ValueChanged += (s, e) =>
		{
			mis_on_valitud.FontSize = e.NewValue;
			mis_on_valitud.Rotation = e.NewValue;
		};
		stepper = new Stepper
		{
			Minimum = 0,
			Maximum = 100,
			Value = 20,
			Increment = 1,
			BackgroundColor = Color.FromRgb(200, 200, 100),
			HorizontalOptions = LayoutOptions.Center
		};
		stepper.ValueChanged += (s, e) =>
		{
			mis_on_valitud.Text = $"Stepper value: {e.NewValue}";
		};

		al = new AbsoluteLayout { Children = { mis_on_valitud, datePicker, timePicker ,picker,slider, stepper } };
        //      AbsoluteLayout.SetLayoutBounds(mis_on_valitud, new Rect(0.5, 0.2, 0.9, 0.2));
        //      AbsoluteLayout.SetLayoutFlags(mis_on_valitud, AbsoluteLayoutFlags.All);
        //      AbsoluteLayout.SetLayoutBounds(datePicker, new Rect(0.5, 0.5, 0.9, 0.2));
        //      AbsoluteLayout.SetLayoutFlags(datePicker, AbsoluteLayoutFlags.All);
        //AbsoluteLayout.SetLayoutBounds(timePicker, new Rect(0.5, 0.7, 0.9, 0.2));
        //AbsoluteLayout.SetLayoutFlags(timePicker, AbsoluteLayoutFlags.All);
        //AbsoluteLayout.SetLayoutBounds(picker, new Rect(0.5, 0.7, 0.9, 0.2));
        //AbsoluteLayout.SetLayoutFlags(picker, AbsoluteLayoutFlags.All);
        //AbsoluteLayout.SetLayoutBounds(slider,new Rect(0.5, 0.7, 0.9, 0.2));
        //      AbsoluteLayout.SetLayoutFlags(slider, AbsoluteLayoutFlags.All);
        //      AbsoluteLayout.SetLayoutBounds(stepper, new Rect(0.5, 1.0, 0.9, 0.2));
        //      AbsoluteLayout.SetLayoutFlags(stepper, AbsoluteLayoutFlags.All);
        var elementid = new View[]
		{
			 mis_on_valitud, datePicker, timePicker, slider, stepper
		};

        for (int i = 0; i < elementid.Length; i++)
        {
            // Устанавливаем размер и позицию
            AbsoluteLayout.SetLayoutBounds(elementid[i], new Rect(0.5, i * 0.16, 0.9, 0.15));

            // Устанавливаем флаги для позиционирования
            AbsoluteLayout.SetLayoutFlags(elementid[i], AbsoluteLayoutFlags.All);  
        }

        Content = al;



    }

    private void Kuupäeva_valimine(object? sender, DateChangedEventArgs e)
    {
        mis_on_valitud.Text = $"Valisite kuupäeva : {e.NewDate:D}";
    }
}