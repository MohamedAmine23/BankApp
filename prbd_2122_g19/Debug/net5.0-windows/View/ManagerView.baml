   M S B A M L   `   `   `  ����H  Dprbd_2122_g19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:prbd_2122_g19.Viewprbd_2122_g19.View  5   	   A%clr-namespace:prbd_2122_g19.ViewModelprbd_2122_g19.ViewModel  5   	   I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5   	   $    prbd_2122_g19.View.ManagerView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:prbd_2122_g19.View     5   	   4vm%clr-namespace:prbd_2122_g19.ViewModel     5   	   Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5   	   -   5        $	��450��5
   "   $	��800��6/     � WindowStartupLocation$  CenterScreen=�6;    � Title 6
   �� *Title+ � DataContext 5      .  (prbd_2122_g19.ViewModel.ManagerViewModel  5   
   -   5        vm��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      �� 5      .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      o� .@�5      m� -   5        $��Logout��5      6+   m� 5      $��Reload��6    m� Command 6+   �� *ReloadDataCommand+5      �� 5       $��2��6   .��6$   CurrentDate:62   (  "System.Windows.Controls.DatePicker  5!      $��3��5"   
      SelectedDate 5!      �� *
DateChange+ �� ElementName$ vm��5"   
   5$      !  PRBD_Framework.MyTabControl  5%   
   -   5          Name$ 
tabControl��5%      $��10q�6-   $��1��69   	   HasCloseButton$
	 True��6F   .@�5&      �� -   5        
 ��Name$
 
ManagerTab��5&      $��Manager��6*   
 � Tag$ Manager��6;   .��5'      �  5(      �� 5)      �� 5*      .+�5,      � $��5q�6    5-      �� 5.      $
��auto �6/   �� 5/      $��* �6/   .+�51      �� .��6    
Agencies6*   �� 52      $��1��6#   ��63   �� *
Agencies+$ vm�� �� SelectedItem 6c   �� *SelectedAgency+$ vm����54      �� 55   "   .R�56   &   �� ��61   �� *Name+57   #   5:      5;        PRBD_Framework.MyDataGrid  5<      -   5          Name$ gridAccesses��5<   �   $��1��6#   &   System.Windows.Controls.DataGrid   CanUserAddRows$ False��6Q      AutoGenerateColumns$ False��6h   ��60   �� *	Clients+   Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$ IdClient��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6C      
IsReadOnly$
 True��5?   F   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6%   ��  �� Path$ User_id�6F     5@      $ 	FirstName��61   $
 auto 6D   $
 True��5A   H    6%   �� $ 	FirstName�6H     5B      $ LastName��61   $
 auto 6C   $
 True��5C   D    6%   �� $
 Name�6D   5K      5L      5N      �� 5O      -   5        $
 TESTTab��5O      $
��Test��6'   $
 test��65   .��5P      �� OK6    5Q      5R      5U      5V      