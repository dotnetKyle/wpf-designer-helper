# wpf-designer-helper

A library that will help with **displaying fake data in the Designer** in Visual Studio. You shouldn't have to run your app to see what it looks like while you are editing XAML.

## Installation

The package is installed via nuget.org: 

* Package Manager Console: `Install-Package dotnetKyle.WpfDesignerHelper`
* Dotnet CLI: `dotnet add package dotnetKyle.WpfDesignerHelper`

## Usage:

> In your ViewModel's constructor, you can set the properties that are bound and this code will only run in the designer and won't affect runtime code.
> ```
> using WpfDesignerHelper;
> 
> namespace Example
> {
>     public class AutoMobileViewModel
>     {
>         public MyViewModel()
>         {
>             if(Designer.Active)
>             {
>                 this.Make = "Toyota";
>                 this.Model = "Tacoma";
>                 this.Year = "2020";
>                 this.WheelSizes = new string[]
>                 { 
>                     "265/75 R15", "265/75 R15", 
>                     "265/75 R15", "265/75 R15" 
>                 };
>             }
>         }
> 
>         public string Make { get; set; }
>         public string Model { get; set; }
>         public string Year { get; set; }
>         public IEnumerable<string> WheelSizes { get; set; }    
>     }
> }
> ```
> 
> In the XAML for the View that uses the View Model, you can specify a > design-time ViewModel by setting the `d:DataContext` to use, like this:
> ```
> <Window x:Class="Example.MainWindow"
>         ...
>         xmlns:local="clr-namespace:Example"
>         mc:Ignorable="d"
>         d:DataContext="{d:DesignInstance Type=local:AutoMobileViewModel, > IsDesignTimeCreatable=True}"
>         ...
>         >
>         <!-- Most important part is the above d:DataContext line. -->
>     <StackPanel Orientation="Vertical">
>         <!-- Make -->
>         <StackPanel Orientation="Horizontal">
>             <Label Content="Make:"/>
>             <TextBlock Text={Binding Make}/>
>         </StackPanel>
> 
>         <!-- Model -->
>         <StackPanel Orientation="Horizontal">
>             <Label Content="Model:"/>
>             <TextBlock Text={Binding Model}/>
>         </StackPanel>
> 
>         <!-- Year -->
>         <StackPanel Orientation="Horizontal">
>             <Label Content="Year:"/>
>             <TextBlock Text={Binding Year}/>
>         </StackPanel>
>         
>         <!-- Wheels -->
>         <StackPanel Orientation="Horizontal">
>             <Label Content="Wheels:"/>
>             <ItemsControl ItemsSource="{Binding WheelSizes}">
>                 <ItemsControl.ItemsPanel>
>                     <ItemsPanelTemplate>
>                         <StackPanel Orientation="Vertical"/>
>                     </ItemsPanelTemplate>
>                 </ItemsControl.ItemsPanel>
>                 <ItemsControl.ItemTemplate>
>                     <DataTemplate>
>                         <TextBlock Text="{Binding}"/>
>                     </DataTemplate>
>                 </ItemsControl.ItemTemplate>
>             </ItemsControl>
>         </StackPanel>
>     </StackPanel>
> </Window>
> ```