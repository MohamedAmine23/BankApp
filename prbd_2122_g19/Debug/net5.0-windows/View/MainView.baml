   M S B A M L   `   `   `  ����H  Dprbd_2122_g19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:prbd_2122_g19.ViewModelprbd_2122_g19.ViewModel  5   	   -clr-namespace:prbd_2122_g19prbd_2122_g19  5   	   7 clr-namespace:prbd_2122_g19.Viewprbd_2122_g19.View  5   	   I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5	   	   !    prbd_2122_g19.View.MainView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4vm%clr-namespace:prbd_2122_g19.ViewModel     5   	   )mclr-namespace:prbd_2122_g19     5   	   .v clr-namespace:prbd_2122_g19.View     5   	   Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5	   	   -   5        $	��450��5   !   $	��800��6.     � WindowStartupLocation$  CenterScreen=�6:    � Title 6	   �� *Title+ � DataContext 5      +   %prbd_2122_g19.ViewModel.MainViewModel  5   
   -   5        vm��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��1* �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      o� .@�5      m� -   5        $��Logout��5      6+   m� 5      $��Reload��6    m� Command 6+   �� *ReloadDataCommand+5      �� 5      $��2��6   .��6$   CurrentDate:62   (  "System.Windows.Controls.DatePicker  5       $��3��5!   
      SelectedDate 5       �� *
DateChange+ �� ElementName$ vm��5!   
   5#      !  PRBD_Framework.MyTabControl  5%      -   5          Name$ 
tabControl��5%      $��10q�6)   $��1��65   	   HasCloseButton$
	 True��6B   .@�5&   
   �� -   5        
 ��Name$
 AccountsTab��5&      $��Accounts��6'   
 � Tag$ Accounts��69   .��5'      %   prbd_2122_g19.View.AccountsView  5)      5*      5+      5,      