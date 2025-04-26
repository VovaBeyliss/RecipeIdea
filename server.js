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
 
db.run('CREATE TABLE IF NOT EXISTS recipes (id INTEGER PRIMARY KEY, name TEXT, description TEXT, timeCooking TEXT, ingridients TEXT)', (err) => {
    if (err) {
        console.error('Помилка при створенні таблиці:', err.message);
    }
})
 
app.post('/api/save', (req, res) => {
    console.log('Отримано запит на збереження рецепту:', req.body);
    const { name, description, timeCooking, ingridients } = req.body;
    
    if (!name || !description) {
        console.log('Відсутні обов\'язкові поля');
        return res.status(400).json({ success: false, error: "Відсутні обов'язкові поля" });
    }

    db.run('INSERT INTO recipes (name, description, timeCooking, ingridients) VALUES (?, ?, ?, ?)', 
        [name, description, timeCooking, ingridients], 
        function(err) {
            if (err) {
                console.error('Помилка бази даних:', err.message);
                return res.status(500).json({ success: false, error: "Помилка бази даних" });
            }
            console.log('Рецепт успішно збережено з ID:', this.lastID);
            res.json({ success: true, id: this.lastID });
        }
    )
})
 
app.get('/api/latest', (req, res) => {
    console.log('Отримано запит на останній рецепт');
    db.get('SELECT * FROM recipes ORDER BY id DESC LIMIT 1', [], (err, row) => {
        if (err) {
            console.error('Помилка при отриманні рецепту:', err.message);
            return res.status(500).json({ success: false, error: "Помилка бази даних" });
        }
        if (!row) {
            console.log('Рецептів не знайдено');
            return res.json({ success: true, data: null });
        }
        console.log('Знайдено рецепт:', row);
        res.json({ success: true, data: row });
    })
})

app.get('/api/all', (req, res) => {
    console.log('Отримано запит на всі рецепти');
    db.all('SELECT * FROM recipes ORDER BY id DESC', [], (err, rows) => {
        if (err) {
            console.error('Помилка при отриманні рецептів:', err.message);
            return res.status(500).json({ success: false, error: "Помилка бази даних" });
        }
        console.log(`Знайдено ${rows.length} рецептів`);
        res.json(rows);
    })
})
 
app.listen(3000, () => {
    console.log('Сервер запущено на http://localhost:3000');
})