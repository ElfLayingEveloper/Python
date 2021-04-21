const quoteDisplayElement = document.getElementById('text');
const quoteInputElement = document.getElementById('textbox');
const timerElement = document.getElementById('timer');
const wpmElement = document.querySelector('.Wpm');
const AccuracyElement = document.querySelector('.Accuracy');

let wpm;
let charsInInput = 0;
let accuracy;
let startTime;
let currentTime = 0;
let finished = false;
let isError = false;
let errors = 0;
let hadProblemsBefore = false;
let points = 0;

quoteInputElement.addEventListener('input', (event) =>{
    const arrayQuote = quoteDisplayElement.querySelectorAll('span')
    const arrayValue = quoteInputElement.value.split('');
    arrayQuote.forEach((characterSpan, index) =>{
    const character = arrayValue[index];
        if (character == null) {
            characterSpan.classList.remove('correct');
            characterSpan.classList.remove('incorrect');
            finished = false;
        }
        else if (character === characterSpan.innerText) {
            characterSpan.classList.add('correct');
            characterSpan.classList.remove('incorrect');
            isError = false;
        } else{
            characterSpan.classList.remove('correct');
            characterSpan.classList.add('incorrect');
            finished = false;
            isError = true;
        }
    })
    if (!isError){
        charsInInput++;
        hadProblemsBefore = false;
    }
    else{
        if (!hadProblemsBefore)
        {
        errors++;
        hadProblemsBefore = true;
        }
    }
    if (charsInInput > arrayValue.length){
        charsInInput = arrayValue.length;
    }
})

function finishing(){
if(quoteInputElement.value.includes(quoteDisplayElement.innerText))
    {
    finished = true;
    quoteInputElement.classList.add('finish');

    ///

    quoteDisplayElement.innerText = "Well Done! Now... lets continue? :D";
    quoteDisplayElement.classList.add('changeTextFont');
        
    if (accuracy == 100){
        points = wpm * (accuracy/100) + 50;
        quoteDisplayElement.innerText = "OMG... you are awesome! You completed the race without any mistakes!!! Congrants, you've got extra 50 points for that.";
    }else{
        points = wpm * (accuracy/100);
    }
    

    localStorage.setItem("Wpm",wpm);
    localStorage.setItem("accuracy",accuracy);
    localStorage.setItem("Time", currentTime);
    
    }
}

async function renderNewQuote() {
    const quote = await quoteDisplayElement.innerText;
    quoteDisplayElement.innerHTML = '';
    quote.split('').forEach(character => {
        const characterSpan = document.createElement('span');
        characterSpan.innerText = character;
        quoteDisplayElement.appendChild(characterSpan);
    })
    startTimer();
}

function startTimer() {
    
    timerElement.innerText = 0;
    startTime = new Date();
    let intervalId = window.setInterval(() =>{
        finishing();
        timer.innerText = getTimerTime();
        wpm = (charsInInput / 5) / (currentTime / 60);
        wpmElement.innerText = wpm;
        AccuracyElement.innerText = ((charsInInput - errors)/charsInInput) * 100 + '%';
        currentTime++;
        if (finished)
        window.clearInterval(intervalId);
    }, 1000)
}

function getTimerTime() {
    return Math.floor((new Date() - startTime) / 1000)
}

renderNewQuote();

/*
1)refer to the homepage.
2)use the function "finishing" to send data of the statistic.
3)add the points visibility on the page.
4)host/use a domain and say Gadi that the work was 
done (sure, I have to send him a link or something).
5) *extra* I'll add some dynamic like: while the wpm will change I'll
display some texts for making fun (I'm fast as fack!!! Boii>> 
or: Man, have to train a bit, etc.)
*/