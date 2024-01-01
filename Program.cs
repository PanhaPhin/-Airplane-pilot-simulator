/*ConsoleKeyInfo key;
int speed = 1000;
int height = 1000;
int speed1 = 0;
int speed2 = 0;
int height1 = 0;
int height2 = 0;
int n1 = Random.Shared.Next(-200, 201);
int n2 = Random.Shared.Next(-200, 201);
do
{
    height1 = 7 * speed1 - n1;
    height2 = 7 * speed2 - n2;
    Console.SetCursorPosition(0, 0);
    Console.WriteLine(
        @"
--------------Airplane Pilot Simulator--------------

MaxHeight: {0}
Airplane: {1}m [{2}km/h]
MinHeight: {3}

Flight controller #1: Phnom Penh ((Natural factor N: 200)
Flight controller #2: Siem Riep ((Natural factor N: -200)
---------------------------------------------------------------
Press Arrows:
UpArrow : Altitude increase by +250m (with Shift +500m)
DownArrow : Altitude decrease by +250m (with Shift -500m)
RightArrow : Speed increase by +50km/h (with Ctrl +150km/h)
LeftArrow : Speed increase by -50km/h (with Ctrl -150km/h)

Press ENTER to add new air controller
Press DEL to delete an air controller
Press ESC to exit the program
", height1, height, speed, height2
        );
    key = Console.ReadKey(true);

    if (key.Key == ConsoleKey.UpArrow)
    {
        height += 250;
    }
    if (key.Key == ConsoleKey.DownArrow)
    {
        height -= 250;
    }
    if (key.Key == ConsoleKey.RightArrow)
    {
        speed += 50;
    }
    if (key.Key == ConsoleKey.LeftArrow)
    {
        speed -= 50;
    }
    if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.UpArrow)
    {
        height += 500;
    }
    if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.DownArrow)
    {
        height -= 500;
    }
    if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.RightArrow)
    {
        speed += 150;
    }
    if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.LeftArrow)
    {
        speed -= 150;
    }
    if (key.Key == ConsoleKey.Enter)
    {
    }
    if (key.Key == ConsoleKey.Delete)
    {
    }
    if (key.Key == ConsoleKey.Escape)
    {
        Environment.Exit(0);
    }

} while (true);*/