   M S B A M L   `   `   `  ����I  ESerialTransmit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SerialTransmitSerialTransmit  5   	       SerialTransmit.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SerialTransmit     5   	     � Title$  File2Serial��5   	   $	��350��6   $	��525��6*    � WindowStartupLocation$ CenterScreen=�66   $	��525��6[   $	��525��6j   $	��350��6y   $	��350��6�    � 
ResizeMode$ NoResize=�6�    � WindowStyle$ ThreeDBorderWindow=�6�   .��5
      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ comboBox_SerialSelect��5      $
��Left=�62   $��	10,94,0,0q�6M   $	��Top=�6`   $	��102��6x   $��22��6�   .@�5      �� $
��9600��6   $
��Left=�6*   $	��128��6E   �� 5      $��19200��6   $
��Left=�6+   $	��128��6F   �� 5      $��115200��6   $
��Left=�6,   $	��128��6G   �� 5      $��256000��6   $
��Left=�6,   $	��128��6G   �� 5      $��3000000��6   $
��Left=�6-   $	��128��6H   5      �� 5   
   -   5         ��Name$ textBox_InputFile��5      $
��Left=�6-   $��20��6H   $��131,279,0,0q�6T    �� TextWrapping$
 Wrap=�6i   $	��Top=�6}   $	��315��6�   6�   �� 5   
   -   5         ��Name$ button_SelectFile��5      $��Open.��6,   $
��Left=�6<   $��451,279,0,0q�6W   $	��Top=�6l   $��43��6�   $��20��6�   6�   �� 5   
   -   5        $ Button_Start_Stop��5      $��
Start/Stop��6,   $
��Left=�6A   $��
10,279,0,0q�6\   $	��Top=�6p   $	��116��6�   $��20��6�   6�   �� 5   
   -   5        $ textBox_Output��5      $��Right=�6*   $	��256��6F   $��	0,10,10,0q�6S   $
 Wrap=�6f   $	��Top=�6z   $	��378��6�   "	 �� VerticalScrollBarVisibility$
	 Auto=�6�   ��. 6�   �� 5   
   -   5        
 ��Name$
 	label_COM��5      $
��COM:��6#   $
��Left=�62   $��	10,10,0,0q�6M   $	��Top=�6`   �� 5   
   -   5        $
 label_COM_Copy��5      $��	BaudRate:��6(   $
��Left=�6<   $��	10,68,0,0q�6W   $	��Top=�6j   �� 5   
   -   5        $ textBox_COMs��5      $
��Left=�6(   $��23��6C   $��	10,36,0,0q�6O   $
 Wrap=�6b   $	��Top=�6v   $	��102��6�   6�   �� 5   
   -	   5        $ textBox_Interval��5      $
��Left=�6,   $��23��6G   $��
10,243,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��102��6�   $��0��6�   �� 5   
   -
   5        $
 label��5      $��Interval(mS)��6   $
��Left=�66   $��
10,217,0,0q�6Q   $	��Top=�6e   5      5       