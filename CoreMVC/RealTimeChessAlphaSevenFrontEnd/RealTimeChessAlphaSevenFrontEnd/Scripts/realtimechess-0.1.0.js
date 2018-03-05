﻿// Sample Code From: http://corehtml5canvas.com/
// Title:       HTML5-Canvas
// Author:      David Geary
// Publisher:   PrenticeHall
// Link:        https://www.pdfdrive.net/core-html5-canvas-d4208966.html



var canvas = document.getElementById('canvas'),
    context = canvas.getContext('2d'),
    nFontHeight = 15,

    nCellCountX = 8,
    nCellCountY = 8,
    
    nMarginX = 0,
    nMarginY = 0,

    nCellSizeX = (canvas.width - (2 * nMarginX)) / nCellCountX,
    nCellSizeY = (canvas.height - (2 * nMarginY)) / nCellCountY;


// Functions..........................................................
function drawCircle() {
    context.beginPath();
    context.arc(canvas.width / 2, canvas.height / 2, RADIUS, 0, Math.PI * 2, true);
    context.stroke();
}


function drawLabels() {
    var numerals = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12], angle = 0, numeralWidth = 0;
    numerals.forEach(function (numeral) {
        angle = Math.PI / 6 * (numeral - 3);
        numeralWidth = context.measureText(numeral).width;
        context.fillText(numeral,
            canvas.width / 2 + Math.cos(angle) * (HAND_RADIUS) - numeralWidth / 2,
            canvas.height / 2 + Math.sin(angle) * (HAND_RADIUS) + nFontHeight / 3);
    });
}



function drawBackground() {
    context.clearRect(0, 0, canvas.width, canvas.height);
   
    context.lineWidth = "1";
    context.strokeStyle = "black";

    console.log("Cell Size Y=" + nCellSizeY);
    console.log("Cell Size X=" + nCellSizeX);

    var bCellColor = false
    var nCellPositionY = nMarginY;
    for (var y = 0; y < nCellCountY; y++)
    {
        console.log("PositionY=" + nCellPositionY);

        var nCellPositionX = nMarginX;
        for (var x = 0; x < nCellCountX; x++)
        {
            context.fillStyle = (bCellColor == true) ?  "darkgray" : "lightblue";

            console.log("PositionX=" + nCellPositionX);

            context.beginPath();
            console.log("Drawing Rectangle, PosX:" + nCellPositionX + ", PosY:" + nCellPositionY);
            context.rect(nCellPositionX, nCellPositionY, nCellSizeX, nCellSizeY);

            context.fill();
            //context.stroke();     

            nCellPositionX += nCellSizeX;
            bCellColor = !bCellColor;
        }
        nCellPositionY += nCellSizeY;
        bCellColor = !bCellColor;
    }
}


// Initialization................................................
context.font = nFontHeight + 'px Arial';
drawBackground();

//loop = setInterval(drawClock, 1000);