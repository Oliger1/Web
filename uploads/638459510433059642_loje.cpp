

#include <iostream>
#include <graphics.h> // or any other 3D graphics library of your choice

int main()
{
    // Initialize the graphics window
    initwindow(800, 600, "3D Scene");

    // Create the blocks
    drawcube(100, 100, 100, 50, 50, 50, RED);
    drawcube(200, 200, 200, 75, 75, 75, BLUE);

    // Create the road
    drawcylinder(400, 300, 300, 20, 100, BLACK);

    // Create the hero
    drawsphere(500, 400, 400, 25, GREEN);

    // Display the scene
    getch();
    closegraph();

    return 0;
}
