   M S B A M L   `   `   `  ����H  Dprbd_2122_g19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:prbd_2122_g19.Modelprbd_2122_g19.Model  5      7 clr-namespace:prbd_2122_g19.Viewprbd_2122_g19.View  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5      )    #prbd_2122_g19.View.TransferCardView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /m!clr-namespace:prbd_2122_g19.Model     5      .v clr-namespace:prbd_2122_g19.View     5      Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5      .��5      �� $��2q�6   $	��660��6"   $
��auto��6.     �� Padding$  10,10,10,10q�6<   
������� �� CornerRadius$ 7��6e   ._�5   
   �  � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $
��Bold"�6   $
��Left=�6*   $��14(�6E   ��6S   �� *Communication+�� 5      $��Right=�6   $
��Bold"�65   $��14(�6G      AmountStyle#��[  6�   ��6V   �� *AmountSigned+ �� 	Converter >   8prbd_2122_g19.View.CurrencyToStringWithPlusSignConverter  6�   �� 5      $��1��6   $
��Left=�6%   �� 5      $�Created on: ��6    �� 5      $
��Bold"�6   �6(   �� *CreationDate+ �� StringFormat$  {0:dd/MM/yyyy}��5      �� 5!      $��1��6   $��center=�6%   �� 5"      $�Effective on: ��6    �� 5#      $
��Bold"�6   �6(   �� *EffectiveDate+$ {0:dd/MM/yyyy}��5$      � 5'      $��2��6    � ColumnDefinitions 5(      �� 5)      $��* �6'   �� 5*      $
��auto �6'   .+�5,      �� �� 5-      $�Created by:��6    �� 5.      $
��Bold"�6   �6(   �� *Owner.FirstName+ �� 5/      $
��Bold"�6   �6(   �� *
Owner.Name+50      �� 51      $��1��6    	 Saldo#��[ 6s   ��6,   �� *CurrentSolde+ 2   ,prbd_2122_g19.View.CurrencyToStringConverter  6s   52      �� 55      $��3��6   �� 56      $�From: ��6    �� 57      $
��Bold"�6   �6(   �� *DebitAccount.Description+ �� 58      $	� ( ��6    �� 59      �6   �� *DebitAccount.Iban+ �� 5:      $	� ) ��6   5;      �� 5<      $��4��6   �� 5=      $
�To: ��6    �� 5>      $
��Bold"�6   �6(   �� *CreditAccount.Description+ �� 5?      $	� ( ��6    �� 5@      �6   �� *CreditAccount.Iban+ �� 5A      $	� ) ��6   5B      � 5C      $��5��6   .+�5D      � y�6   �� *	IsFutur+ +  %PRBD_Framework.BoolToVisibleConverter  .+�5E      �� 
����  �$C��=This transaction is foreseen in the futur. You may Cancel it.��62   �� 5F      $��Right=�6   $��20��6:   $
��auto��6F   $��Cancel��6S   ��6e   �� *CancelTransfer+ �� ElementName$ vm����6�   �� *.+5G      � 5H      y�6   �� *	IsRefused+   .+�5I      �� 
���  ���� 5J      $r�lThis transaction has been refused because it would have given you a balance below the allowed floor value of��6    �� 5K      $
��bold"�6   �60   �� *&$Representative.InternalAccount.Floor+$ vm��5L      5N      5O      � 5P      $��6��6    5Q      �� 5R      $
��auto �6'   �� 5S      $	��250 �6'   .+�5U      �� $��center=�6   $��	Category:��69   �� 5V      $��center=�6   $	��250��68   $��1��6D   ��6T   �� *
Categories+$ vm�� �� Text 6�   �� *Category.Name+$ transferList�� �� SelectedItem 6�   �� *
Category+��5W      �� 5X      .R�5Y      �� ��6)   �� *Name+5Z      5\      5]      5^      5_      5`      