namespace CatanMAUI.Views;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
		GameField_StackLayout.Add(CreateHexagonLine(3,0));
		GameField_StackLayout.Add(CreateHexagonLine(4,100));
		GameField_StackLayout.Add(CreateHexagonLine(5,200));
        GameField_StackLayout.Add(CreateHexagonLine(4, 100));
        GameField_StackLayout.Add(CreateHexagonLine(3, 0));
    }

	public HorizontalStackLayout CreateHexagonLine(int length, int marginLeft)
	{
		var root = new HorizontalStackLayout()
		{
			Margin = new Thickness(0, 0, marginLeft, 0),
            MaximumHeightRequest = 200,
			MaximumWidthRequest = 200
			
        };
		root.HorizontalOptions= LayoutOptions.Center;
		for(int i = 0;i<length; i++)
		{
            root.Add(CreateHexagon());
        }
		

		return root;
    }
	public AbsoluteLayout CreateHexagon()
	{
		var root = new AbsoluteLayout();
		root.HeightRequest = 100;
        root.WidthRequest = 100;
        root.Rotation = 90;

		var image = new Image();
		image.Source = "hexagon.png";
        image.HeightRequest = 100;
        image.WidthRequest = 100;

        var button = new Button();
		button.HeightRequest = 60;
		button.WidthRequest = 60;
		//button.BorderColor = Colors.Yellow;

		root.Add(image);
		root.Add(button);
		root.SetLayoutBounds(image, new Rect(0, 0, 0, 0));
		root.SetLayoutBounds(button, new Rect(0, 0, 0, 0));
        return root;
	}
}