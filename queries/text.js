const { text } = require('express');
const express = require('express');
const mysql = require('mysql');
const path = require('path');
const { callbackify } = require('util');
const bodyParser = require('body-parser');
const { allowedNodeEnvironmentFlags } = require('process');

const app = express();
app.use("/public",express.static("public"));
app.set('veiw engine', 'ejs');
app.set('views', path.join(__dirname, 'views'))

// Create connection
const conn = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password:'kabbalah1',
    database:'work#1'
});

// Connecting DB
conn.connect( err => {
    if (err) {
        console.log(err);
        return err;
    }
    else{
        console.log('Database ----- connected');
    }
});

let urlencodedParser = bodyParser.urlencoded({ extended: false })

app.get('/contact', function(req, res){
    res.render('contact', {qs: req.query});
});
app.post('/contact'), urlencodedParser, function(req, res){
    console.log(req.body);
    res.render('contact', {qs: req.query});
};

let textQuery ="SELECT textstring FROM texts ORDER BY RAND()LIMIT 1;";
let wpmSumQuery = "SELECT vpm_avrg_sum FROM userstats";
let accuracySumQuery = "SELECT accuracy_avrg_sum FROM userstats";


let wpmSUm;
let accuracySum;


let finalWpmQuery ="INSERT ${wpm} INTO userstats ";
let finalAccuracyQuery ="INSERT ${accuracy} INTO texts ORDER BY RAND()LIMIT 1;";



function getTextFromDB(callback){
 conn.query(textQuery,(err,result) =>{
     if (err){
    throw err;
     }
     
    
    theTextResult = result[0].textstring;
   return callback(theTextResult);
});
}
module.exports = {getTextFromDB};

function getWpmSum(callback){
    conn.query(wpmSumQuery,(err,result) =>{
        if (err){
            throw err;
        }
    })
}
function getAccuracySum(callback){
    conn.query(accuracySumQuery,(err,result) =>{
        if (err){
            throw err;
        }
    })
}

