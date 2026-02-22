using System.Windows;
using System.Windows.Controls;

public static class PasswordBoxHelper
{
    public static readonly DependencyProperty BoundPasswordProperty =
        DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxHelper),
            new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

    public static string GetBoundPassword(DependencyObject dp) => (string)dp.GetValue(BoundPasswordProperty);
    public static void SetBoundPassword(DependencyObject dp, string value) => dp.SetValue(BoundPasswordProperty, value);

    private static void OnBoundPasswordChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
    {
        if (dp is not PasswordBox pb) return;
        pb.PasswordChanged -= PasswordChanged;
        var newValue = e.NewValue as string ?? string.Empty;
        if (pb.Password != newValue) pb.Password = newValue;
        pb.PasswordChanged += PasswordChanged;
    }

    private static void PasswordChanged(object? sender, RoutedEventArgs e)
    {
        if (sender is not PasswordBox pb) return;
        SetBoundPassword(pb, pb.Password);
    }
}