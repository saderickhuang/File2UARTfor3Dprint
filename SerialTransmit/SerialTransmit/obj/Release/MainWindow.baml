   M S B A M L   `   `   `  ���� I  ESerialTransmit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SerialTransmitSerialTransmit      SerialTransmit.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:SerialTransmit       � Title$  File2Serial��$	��350��$	��525�� � WindowStartupLocation$ CenterScreen=�$	��525��$	��525��$	��350��$	��350�� � 
ResizeMode$ NoResize=� � WindowStyle$ ThreeDBorderWindow=�.���  � ColumnDefinitions �� .+��� -    ��Name$ comboBox_SerialSelect��$
��Left=�$��	10,94,0,0q�$	��Top=�$	��102��$��22��.@��� $
��9600��$
��Left=�$	��128���� $��19200��$
��Left=�$	��128���� $��115200��$
��Left=�$	��128���� $��256000��$
��Left=�$	��128���� $��3000000��$
��Left=�$	��128���� -    ��Name$ textBox_InputFile��$
��Left=�$��20��$��131,279,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��315���� -    ��Name$ button_SelectFile��$��Open.��$
��Left=�$��451,279,0,0q�$	��Top=�$��43��$��20���� -   $ Button_Start_Stop��$��
Start/Stop��$
��Left=�$��
10,279,0,0q�$	��Top=�$	��116��$��20���� -   $ textBox_Output��$��Right=�$	��256��$��	0,10,10,0q�$
 Wrap=�$	��Top=�$	��378��"	 �� VerticalScrollBarVisibility$
	 Auto=���. 
 �� 
IsReadOnly
 . �� -    ��Name$ 	label_COM��$
��COM:��$
��Left=�$��	10,10,0,0q�$	��Top=��� -   $ label_COM_Copy��$��	BaudRate:��$
��Left=�$��	10,68,0,0q�$	��Top=��� -   $ textBox_COMs��$
��Left=�$��23��$��	10,36,0,0q�$
 Wrap=�$	��Top=�$	��102���� -	   $ textBox_Interval��$
��Left=�$��23��$��
10,243,0,0q�$
 Wrap=�$	��Top=�$	��102��$��0���� -
   $ label��$��Interval(uS)��$
��Left=�$��
10,217,0,0q�$	��Top=�