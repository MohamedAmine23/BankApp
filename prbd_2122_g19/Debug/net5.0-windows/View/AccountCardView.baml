   M S B A M L   `   `   `  ����H  Dprbd_2122_g19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:prbd_2122_g19.Modelprbd_2122_g19.Model  5      7 clr-namespace:prbd_2122_g19.Viewprbd_2122_g19.View  5      A%clr-namespace:prbd_2122_g19.ViewModelprbd_2122_g19.ViewModel  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5	      (    "prbd_2122_g19.View.AccountCardView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /m!clr-namespace:prbd_2122_g19.Model     5      .v clr-namespace:prbd_2122_g19.View     5      4vm%clr-namespace:prbd_2122_g19.ViewModel     5      Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5	      -   5        $  PRBD_Framework.UserControlBase   Name$  uc��5   7   .��5      �� .+�5   
   �� $��12(�6   $
��Bold"�6"   $
��auto��65    �� TextAlignment$ Center=�6B   ��6Y   �� *InternalAccountIban+�� 5   
   $��12(�6   $
��Bold"�6"   $
��auto��64   $ Center=�6A   ��6X   �� *InternalAccount.Description+�� 5   
   $��12(�6   $
��auto��6#   $ Center=�60   ��6G   �� *InternalAccount.AccountType+ �� StringFormat$ 	Type: {0}���� 5   
   $��12(�6   $
��auto��6#   $ Center=�60   ��6G   �� *Type+$ Access: {0}���� 5   
   $��12(�6   $
��auto��6#   $ Center=�60   ��6G   �� *InternalAccount.Floor+$ Floor: {0:C2}���� 5   
   $��14(�6   $
��Bold"�6#   $
��auto��65   $ Center=�6B    	  Saldo#��[  6�   ��6Y   �� *InternalAccount.Solde+ �� 	Converter 2   ,prbd_2122_g19.View.CurrencyToStringConverter  6�   � 5   
   $��10q�6   .+�5      �� $��3q�6   $��80��6    $��
Statements��6,   ��6A   �� *'%MyCustomDataContext.DisplayStatements+ �� ElementName$ uc����6�   �� �� 5      $��3q�6   $��80��6    $��Transfer��6+   ��6>   �� *!MyCustomDataContext.NewTransfer+$ uc����6�   �� 5      5      5      