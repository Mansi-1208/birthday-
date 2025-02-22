<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Let's Celebrate with Cake cutting!</title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/3.12.2/gsap.min.js"></script>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            min-height: 100vh;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            background: linear-gradient(45deg, #ffcad4, #ffd1e3, #e0c3fc, #bde0fe);
            background-size: 400% 400%;
            animation: gradientBG 15s ease infinite;
            font-family: 'Arial', sans-serif;
            overflow: hidden;
        }

        .heading {
            font-size: 3.5rem;
            color: #ff71b6;
            text-shadow: 
                0 0 10px rgba(255, 113, 182, 0.5),
                0 0 20px rgba(255, 113, 182, 0.3),
                0 0 30px rgba(255, 113, 182, 0.2);
            margin-bottom: 2rem;
            text-align: center;
            animation: glow 2s ease-in-out infinite alternate;
        }

        @keyframes glow {
            from {
                text-shadow: 0 0 10px #ff71b6, 0 0 20px #ff71b6, 0 0 30px #ff9ecd;
            }
            to {
                text-shadow: 0 0 20px #ff71b6, 0 0 30px #ff71b6, 0 0 40px #ff9ecd;
            }
        }

        .cake-container {
            position: relative;
            width: 300px;
            height: 300px;
            display: flex;
            flex-direction: column;
            align-items: center;
            cursor: pointer;
        }

        .cake {
            position: relative;
            width: 250px;
            height: 250px;
            transform-style: preserve-3d;
            transform: perspective(1000px) rotateX(5deg);
            transition: transform 0.3s ease;
        }

        .cake:hover {
            transform: perspective(1000px) rotateX(5deg) scale(1.05);
        }

        .layer {
            position: absolute;
            width: 100%;
            background: linear-gradient(to right, #ff9ecd, #ff71b6);
            border-radius: 10px;
            box-shadow: 0 2px 15px rgba(0, 0, 0, 0.2);
            display: flex;
            justify-content: center;
        }

        .layer-1 {
            height: 80px;
            bottom: 0;
            width: 250px;
        }

        .layer-2 {
            height: 70px;
            bottom: 80px;
            width: 220px;
            left: 15px;
            background: linear-gradient(to right, #ffb7e0, #ff8ac7);
        }

        .layer-3 {
            height: 60px;
            bottom: 150px;
            width: 190px;
            left: 30px;
            background: linear-gradient(to right, #ffc4e6, #ffa3d4);
        }

        .frosting {
            position: absolute;
            width: 20px;
            height: 30px;
            background: white;
            border-radius: 50%;
            top: -15px;
        }

        .candle {
            position: absolute;
            width: 20px;
            height: 60px;
            background: linear-gradient(to right, #fff, #ffd1e3);
            top: -60px;
            left: 50%;
            transform: translateX(-50%);
            border-radius: 10px;
            z-index: 10;
        }

        .flame {
            position: absolute;
            width: 20px;
            height: 30px;
            background: linear-gradient(to bottom, #ff9d00, #ff5e00);
            border-radius: 50% 50% 20% 20%;
            top: -25px;
            animation: flicker 1s infinite;
            filter: drop-shadow(0 0 10px #ff9d00);
        }

        .ribbon {
            position: fixed;
            width: 15px;
            height: 50px;
            top: -50px;
            border-radius: 5px;
            animation: ribbonFall 3s linear forwards;
        }

        @keyframes ribbonFall {
            0% {
                transform: translateY(0) rotate(0deg) translateX(0);
            }
            50% {
                transform: translateY(50vh) rotate(180deg) translateX(100px);
            }
            100% {
                transform: translateY(100vh) rotate(360deg) translateX(-100px);
            }
        }

        @keyframes flicker {
            0%, 100% { transform: scale(1); opacity: 1; }
            50% { transform: scale(0.9); opacity: 0.8; }
        }

        .smoke {
            position: absolute;
            width: 10px;
            height: 10px;
            background: rgba(255, 255, 255, 0.8);
            border-radius: 50%;
            filter: blur(5px);
            opacity: 0;
        }

        @keyframes gradientBG {
            0% { background-position: 0% 50%; }
            50% { background-position: 100% 50%; }
            100% { background-position: 0% 50%; }
        }
        .next-page-button {
            position: fixed;
            bottom: 40px;
            padding: 15px 40px;
            font-size: 1.2rem;
            background: linear-gradient(45deg, #ff9ecd, #ff71b6);
            border: none;
            border-radius: 25px;
            color: white;
            cursor: pointer;
            opacity: 0;
            transform: translateY(50px);
            transition: all 0.3s ease;
            box-shadow: 
                0 0 15px rgba(255, 113, 182, 0.5),
                0 0 30px rgba(255, 113, 182, 0.3);
            font-family: 'Arial', sans-serif;
            z-index: 1000;
            display: flex;
            align-items: center;
            gap: 10px;
        }
    
        .next-page-button::after {
            content: '→';
            font-size: 1.4rem;
            transition: transform 0.3s ease;
        }
    
        .next-page-button:hover {
            transform: translateY(-3px) scale(1.05);
            box-shadow: 
                0 0 20px rgba(255, 113, 182, 0.6),
                0 0 40px rgba(255, 113, 182, 0.4);
            background: linear-gradient(45deg, #ffb7e0, #ff8ac7);
        }
    
        .next-page-button:hover::after {
            transform: translateX(5px);
        }
    
        @keyframes pulse {
            0%, 100% {
                transform: scale(1);
            }
            50% {
                transform: scale(1.05);
            }
        }
    
        .next-page-button.show {
            opacity: 1;
            transform: translateY(0);
            animation: pulse 2s infinite;
        }
    
    </style>
</head>
<body>
    <h1 class="heading">Let's Cut the Cake! 🎂</h1>
    <div class="cake-container">
        <div class="cake">
            <div class="layer layer-1">
                <div class="frosting"></div>
                <div class="frosting" style="left: 40px"></div>
                <div class="frosting" style="right: 40px"></div>
            </div>
            <div class="layer layer-2">
                <div class="frosting"></div>
                <div class="frosting" style="left: 35px"></div>
                <div class="frosting" style="right: 35px"></div>
            </div>
            <div class="layer layer-3">
                <div class="frosting"></div>
                <div class="frosting" style="left: 30px"></div>
                <div class="frosting" style="right: 30px"></div>
                <div class="candle">
                    <div class="flame"></div>
                </div>
            </div>
        </div>
    </div>
    <button class="next-page-button">Next Page</button>

    <script>
        const cake = document.querySelector('.cake-container');
        const candle = document.querySelector('.candle');
        const flame = document.querySelector('.flame');
        let isClicked = false;

        const ribbonColors = [
            'linear-gradient(45deg, #FF9ECD, #FF71B6)',
            'linear-gradient(45deg, #FFB7E0, #FF8AC7)',
            'linear-gradient(45deg, #FFC4E6, #FFA3D4)',
            'linear-gradient(45deg, #E0C3FC, #BDE0FE)',
            'linear-gradient(45deg, #FFCAD4, #FFD1E3)',
            'linear-gradient(45deg, #B5EAD7, #C7F9CC)',
            'linear-gradient(45deg, #FF9AA2, #FFB7B2)',
            'linear-gradient(45deg, #FFDAC1, #FFE5D9)'
        ];

        function createRibbon() {
            const ribbon = document.createElement('div');
            ribbon.className = 'ribbon';
            ribbon.style.left = `${Math.random() * window.innerWidth}px`;
            ribbon.style.background = ribbonColors[Math.floor(Math.random() * ribbonColors.length)];
            document.body.appendChild(ribbon);

            ribbon.addEventListener('animationend', () => {
                ribbon.remove();
            });
        }

        function startCelebration() {
            if (isClicked) return;
            isClicked = true;

            // Fade out candle smoothly
            gsap.to(candle, {
                opacity: 0,
                y: -20,
                duration: 1,
                ease: "power2.out",
                onComplete: () => candle.remove()
            });

            // Start ribbon rain
            const ribbonInterval = setInterval(() => {
                for (let i = 0; i < 5; i++) {
                    setTimeout(() => createRibbon(), i * 100);
                }
            }, 200);

            // Show next page button after 2 seconds
            setTimeout(() => {
                const nextButton = document.querySelector('.next-page-button');
                nextButton.classList.add('show');
            }, 2000);

            // Stop ribbon rain after 5 seconds
            setTimeout(() => {
                clearInterval(ribbonInterval);
            }, 5000);
        }

        // Add button click handler
        document.querySelector('.next-page-button').addEventListener('click', () => {
            // You can replace this with your actual next page URL
            window.location.href = 'Final.html';
        });

        cake.addEventListener('click', startCelebration);
    </script>
</body>
</html>
