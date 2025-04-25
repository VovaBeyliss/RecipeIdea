const express = require('express');
const sqlite3 = require('sqlite3').verbose();
const bodyParser = require('body-parser');
const path = require('path');
const app = express();
const db = new sqlite3.Database('recipes.db');
const cors = require('cors');
app.use(cors());
 
app.use(bodyParser.json());
app.use(express.static(path.join(__dirname, 'public')));
 
db.run('CREATE TABLE IF NOT EXISTS recipes (id INTEGER PRIMARY KEY, name TEXT, description TEXT, timeCooking TEXT, ingridients TEXT)');
 
app.post('/api/save', (req, res) => {
    const { name, description, timeCooking, ingridients } = req.body;
    db.run('INSERT INTO recipes (name, description, timeCooking, ingridients) VALUES (?, ?, ?, ?)', [name, description, timeCooking, ingridients], function(err) {
        if (err) {
            return res.json({ success: false });
        }
        res.json({ success: true });
    })
})
 
app.get('/api/latest', (req, res) => {
    db.get('SELECT * FROM recipes ORDER BY id DESC LIMIT 1', [], (err, row) => {
        if (err) {
            return res.json({ success: false });
        }
        res.json({ success: true, data: row });
    })
})
 
app.listen(3000, () => {
    console.log('Server running at http://localhost:3000');
})