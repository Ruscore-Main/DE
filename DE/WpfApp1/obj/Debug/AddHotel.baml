   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.AddHotel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$%  Добавление отеля��5   	   $	��220��6"   $	��400��6/   $	��220��6;   $	��400��6K   .��5	      �  � RowDefinitions 5
   
   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��60 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*    � ColumnDefinitions 5   
   �� 5      $	��155 �6   6-   �� 5      6!   .+�5   
   �� $"��Название отеля:��6   $��0��6*   69   �� 5   
   $,��&Количество звезд(1-5): ��6   $��1��62   6A   �� 5   
   $#��Описание отеля: ��6   $��2��6+   6:   �� 5   
   $��Страна: ��6   $��3��6#   62   �� 5   
   -   5         ��Name$ TxtNameHotel��5      $��0��6(   $��1��65   6G   �� 5   
   -   5         ��Name$ sldCountStars��5       �� TickPlacement$ BottomRight=�6(    �� IsSnapToTickEnabled .  �� TickFrequency$ 1Q�6_   $��1��6q   $��1��6~    � Maximum$ 5Q�6�   �� 5   
   -   5        $ TxtDescriptionHotel��5      	 �� TextWrapping$
	 Wrap=�6/   
 �� AcceptsReturn
 . " �� VerticalScrollBarVisibility$ Visible=�6X   $��2��6~   $��1��6�   6�   �� 5   
   -   5         ��Name$ CmbNameCountry��5      $��3��6+   $��1��68    �� DisplayMemberPath$
 Name��6H   6c   �� 5   
   -   5         ��Name$ BtnAddHotel��5      $��4��6&   $��2��63   $��Добавить��6a   6v   5      5      