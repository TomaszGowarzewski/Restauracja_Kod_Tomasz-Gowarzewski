   M S B A M L   `   `   `  ����F  BRestauracja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RestauracjaRestauracja  5   	        Restauracja.SettingsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Restauracja     5   	     � Title$  
Ustawienia��5   	   $��207.919��6   $��340.692��6-    � 
ResizeMode$ NoResize=�6=    � DataContext 5	      )  #Restauracja.SettingsWindowViewModel  5
   
   6*   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*    � ColumnDefinitions 5   
   �� 5      $	��150 �6   6-   �� 5      .+�5   
   �� $��0��6   $��0��6    $��Serwer Smtp��6-   $��Center=�6C   $��80��6a   6n   �� 5   
   $��0��6   $��1��6    $��Użytkownik��6-   $��Center=�6B   $��74��6_   6l   �� 5   
   $��0��6   $��2��6    $��Hasło��6-   $��Center=�6=   $��42��6[   6h   �� 5   
   $��0��6   $��3��6    $��Port (Domyślnie 587)��6-   $��Center=�6L   6l   �� 5   
   $��1��6   $��0��6"   $��Center=�6L   $	��5,6q�6g   $��18��6t   ��6/   �� *
SmtpServer+6�   �� 5   
   $��1��6   $��1��6"   $��Center=�6J   $	��5,6q�6e   $��18��6r   ��6/   �� *	EmailUser+6�   �� 5   
   $��1��6   $��2��6"   $��Center=�6N   $	��5,6q�6i   $��18��6v   ��6/   �� *EmailPassword+6�   �� 5    
   $��1��6   $��3��6"   $��Center=�6E   $	��5,6q�6`   $��18��6m   ��6/   �� *Port+6{   �� 5!   
   $��
Zatwierdź��6   $��4��6F   $��Bottom=�6S   $��1��6o   $��0,0,0,6q�6   ��6%   �� *SaveSettings+6   5"      5#      