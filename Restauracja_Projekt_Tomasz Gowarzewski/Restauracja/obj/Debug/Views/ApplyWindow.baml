   M S B A M L   `   `   `  ����F  BRestauracja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RestauracjaRestauracja  5   	       Restauracja.ApplyWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Restauracja     5   	     � Title$  
Zamowienie��5   	   $	��640��6   $	��480��6)    � 
ResizeMode$ NoResize=�65   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��300* �6   �� 5      $	��100 �6   �� 5      $
��150* �6   �� 5      $	��58* �6   .+�5   
   �� $��0��6   ��6    �� *
DishesList+ �� NotifyOnSourceUpdated .  �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5      .R�5      �� ���#CCCCCC$��1q�63   ._�5      �  � ColumnDefinitions 5      �� 5   "   $	��370 �63   6A   �� 5   "   $��40 �63   6@   .+�5      �� ��6$   �� *
DishName+ �� Mode$ TwoWay=�6Q   �� 5      $��Right=�6|   $��1��6�   ��6$   �� *Price+$ TwoWay=�   localPriceConverter �� 	Converter# [  6�   5      5      5      5       � 5!   
   $��1��6    5"      �� 5#      $	��220 �6#   61   �� 5$      $	��200 �6#   61   .+�5&      �� $��SUMA : ��6   $��Right=�6&   $��30(�6B   $��Center=�6P   6m   �� 5'      $��1��6[   $��30(�6k   $
��Left=�6y   $��Center=�6�   ��6   �� *Sum+# [  6�   5(      � 5*   
   $��2��6   $��10q�6    5+      �� 5,      $��30 �6    6.   �� 5-      $��* �6    6-   .+�5/      �� $��Uwagi do zamowienia:��6   $��0��63   $��Center=�6C   $��2��6`   6v   �� 50      $��1��6   ��6#   �� *InformationToOrder+$ TwoWay=�51      � 52   
   $��3��6   $��10q�6    53      �� 54      $��50 �6#   60   �� 55      $	��275 �6#   61   �� 56      $	��106 �6#   61   .+�58      �� $��
Zatwierdź��64   $��Center=�6H   $��2��6c   $��Center=�6t   ��6   �� *	SendOrder+6t   �� 59      $��e-mail��6   $
��Left=�6&   $��0��6A   $��Center=�6R   �� 5:      $��Center=�63   $��1��6O   ��6   �� *	DestEmail+6O   5;      5<      5=      