   M S B A M L   `   `   `  ����I  EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework  5   	   H Dprbd_2122_g19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:prbd_2122_g19.ViewModelprbd_2122_g19.ViewModel 5   	   "   prbd_2122_g19.View.LoginView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5   	   4vm%clr-namespace:prbd_2122_g19.ViewModel     5   	   -   5           PRBD_Framework.WindowBase   Name$  window��5   	    � Title$ Login��5
   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�5   F   $	��250��5   	   $	��200��6    � SizeToContent$ WidthAndHeight=�5   	    +� FocusedElement 5   	   ��  �� ElementName$ txtEmail�� � DataContext 5      , &prbd_2122_g19.ViewModel.LoginViewModel  5   
   -   5        vm��5      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��2* �6   	 � RowDefinitions	 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        
 ��Name$
 label��5      $��Email��6   $��Center=�6/   $��5q�6J   �� 5   
   -   5         ��Name$ txtEmail��5       �� TextWrapping$
 Wrap=�6$   $��1��68   $��Center=�6H   ��5      �� *Email+ �� UpdateSourceTrigger$ PropertyChanged=�6N   �� 5    
   $��Password��6   $��1��6#   $��Center=�60   $��5q�6K   G� 5!   
   -   5         G�Name$ txtPassword��5!      #   PRBD_Framework.PasswordHelper   Attach$
 True��5"      $��1��5$      $��1��6#   $��Center=�63      Password 5#      �� *
Password+$ PropertyChanged=�5$   3   ]� 5%   
   $��2��6   $��2��6!   $��Center=�65   $��Center=�6P   $��10q�6m   .+�5&      �� -   5         ��Name$ 	btnCancel��5&      $��Cancel��6(   $
��Left=�5'      $	��Top=�60   $��75��6H    �� IsCancel$
 True��6S   $��0,0,10,0q�6c   �� 5(      -   5        $ btnLogin��5(      $��Login��6'   $
��Left=�5)      $	��Top=�60   $��75��6H    �� 	IsDefault$
 True��6S   $��10,0,0,0q�6d   ��5*      �� *LoginCommand+5+      ]� 5,   
   $��3��6   $��2��6!   .+�5-      �� $
��auto��6   $
��Wrap=�6&    �� TextAlignment$ Center=�6:   $��Center=�6Q   $	��220��6n   �� 5.      $5�/If you don't have a login and a password, click��6    �� 5/      .�6   �� $
�here��6!   60    �� 50      $�to sign-up.��6   51      52      53      54      