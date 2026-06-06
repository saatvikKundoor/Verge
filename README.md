# Verge 🎰

> *A gambling-powered AP Calc BC study tool. Spin the wheel, bet your coins, and prove the series converges or diverges... or lose everything trying.*

---

## 🎮 [Play Verge →](https://saatvikk.itch.io/verge)

---

## What Is Verge?

Verge is an AP Calculus BC study game focused on **Series convergence and divergence tests**, with a twist. Spin a wheel to land on a random series question, decide if it converges or diverges, and place a bet before you answer. Get it right and your riches grow, but if you're wrong you'll feel the loss.

Built for students who need to actually learn their series tests, not just memorize them.

---

## 📸 Preview

https://github.com/user-attachments/assets/f1b63cb3-d610-41b6-b64f-f7edf43baad2

---

## 🧠 Series Tests Covered

- **Geometric Series Test** — Does |r| < 1?
- **Nth Term Test** — Does the limit ≠ 0?
- **Integral Test** — Continuous, positive, decreasing?
- **Direct Comparison Test** — Less than Converging Series, converges; Greater than Diverging Series, diverges
- **Limit Comparison Test** — Ratio to a known series
- **Alternating Series Test (AST)** — Decreasing and limit = 0?
- **Ratio Test** — L < 1, L > 1, or inconclusive?

---

## 🎲 How to Play

1. **Set your bet** — Choose a percentage of your current coin balance before you answer.
2. **Spin the wheel** — Land on a random series type.
3. **Read the question** — A specific series expression is shown.
4. **Answer** — Does it converge or diverge?
   - ✅ Correct → Win your bet back **plus** your wager of coins.
   - ❌ Wrong → Lose the coins you wagered.
5. **Keep stacking** — The higher your coin count, the better your score. Don't go broke.

> ⚠️ You can bet anywhere from 0% to 100% of your balance. High risk, high reward, just make sure to not get greedy

---

## 🚀 Quick Start

The game runs entirely in the browser, no install is needed.

**[→ Open Verge](https://saatvikk.itch.io/verge)**

---

## ⚙️ How It Works

Questions are drawn from a curated bank of series questions, ranging from trigonometry to factorials. The wheel spin animation is made in C# script, calibrating the spin time, randomizing rotations, and calculating end results. 

The gambling system is derived from the slider value. Using a script to get get the value of the slider, percentages are calculated using basic math and results are based on user answers, with a corresponding percentage loss/win based on bet amounts. 

Animations for the arrows were handmade, simply mapping position movements across a second. Audio was controlled using buttons and an Audio Source using the PlayOneShot() feature. Through that, buttons were the main drivers of audio, such as spin sounds playing when the spin button is pressed or button sounds in general. Finally, arrays are used to help with managing the updating UI elements, properly creating popups and changing multiple UI elements at the same time to fine tune the user experience. 

---

## 🛠️ Built With

- **Unity** — Game Engine used for assets, designing, and building entire game systems.
- **VS Code** — Used for scripting the game through helping with animations, calculations, etc. 
- Series question bank — hand-written and solved through my AP Calc class. 

---

## 📚 Credits

Unity Asset Store was used for the various UI Elements. Freesound.org was used for sound effects and background audio. 
