const text = require('./queries/text');
const express = require('express');
const path = require('path');
const app = express();

// viewed at http://localhost:8080
app.use("/public",express.static("public"));
app.get('/', function(req, res) {
    const textResult = '';
    text.getTextFromDB(function(result){
    kaka = result;
     
    res.render('Home', {
        kaka: kaka
    });
    });
});
app.set('view engine', 'ejs'); // The ejs template engine that the app is going to use
app.set('views', path.join(__dirname, 'views'))


app.listen(8080, ()=>{
    console.log('server has started on port 8080');
});