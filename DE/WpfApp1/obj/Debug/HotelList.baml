   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.HotelList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  	HotelList��5	   	   $	��550��6   $	��550��6+   $	��900��68   $	��900��6G    � 	Resources 5
       �� 
TargetType   PaginationButton �� Property �� Value��%�   &	        �� 5   
   " ��6   .�5      ��  � ��
 �����6;   �� 5       � �� �#bae3e86=   �� 5       � ��$ 22(�6)   66   �� 5       � ��
 �����6<   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      6!    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $	��160 �6   6+   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
hotelTable��5      {�.    
IsReadOnly . $��0��6H   $��0��6X   
�������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$!	 Название отеля��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   ��  �� Path$
 Name�  5      $	 Кол-во звезд��6%   $
 * 6;    6E   �� $ CountOfStars�  5      $#	 Название страны��6%   $
 * 6>    6H   �� $ CountryName�  5       $	 Кол-во туров��6%   $
 * 6;    6E   �� $ 
ToursCount�4  .System.Windows.Controls.DataGridTemplateColumn  5!      $
 * 6)      CellTemplate 5"      �� 5#      .R�5$      �� -   5        .��5$   :   Редактировать6I   5%      5'      5)      �� 5*   
   $��1��6   $��0��6   .+�5+      �� -   5        $��CountElementsOnPage��5+   1   $
��Left=�6   $��23��6L   $��
730,80,0,0q�6X   $��Comic Sans MS)�6l    �� TextWrapping$
 Wrap=�6�   $��10��6�   $	��Top=�6�   $	��120��6�   6�   �� 5,      $$��Кол-во элементов��6   $
��Left=�6/   $��594,75,10,0q�6J   $	��Top=�6_   �� 5-      -   5        $��btnPrev��5-   N   #��[  6   $��<��6?   $
��Left=�6]   $��
325,53,0,0q�6x   $	��Top=�6�   $��75��6�   6�   �� 5.      -   5        $��btnNext��5.   d   #��[  6   $��>��6U   $
��Left=�6s   $��
405,53,0,0q�6�   $	��Top=�6�   $��75��6�   �� 5/      -   5         ��Name$ btnLast��5/   h   #��[  6   $��>>��6U   $
��Left=�6y   $��
485,53,0,0q�6�   $	��Top=�6�   $��75��6�   �� 50      -   5        $��currentPageLabel��50      $(��"Текущая страница: 1��6,   $
��Left=�6J   $��	10,49,0,0q�6e   $	��Top=�6x   �� 51      -	   5        $��pageCountLabel��51      $7��1Общее количество страниц: 1��6*   $
��Left=�6P   $��	10,75,0,0q�6k   $	��Top=�6~   �� 52      -
   5        $ btnFirst��52   i   #��[  6   $��<<��6V   $
��Left=�6{   $��
245,53,0,0q�6�   $	��Top=�6�   $��75��6�   �� 53      -   5        $!��Добавить отель��53       �� Left$	 325��6.   
 �� Top$	 101��6@   $	��155��6Q   $��33��6]   6i   54      55      56      