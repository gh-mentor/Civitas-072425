const mysql = require('mysql');
const bcrypt = require('bcrypt');

class Database {
    constructor(dbConfig) {
        this.connection = mysql.createConnection(dbConfig);
    }

    connect() {
        return new Promise((resolve, reject) => {
            this.connection.connect((err) => {
                if (err) {
                    reject(err);
                } else {
                    resolve();
                }
            });
        });
    }

    query(sql, params) {
        return new Promise((resolve, reject) => {
            this.connection.query(sql, params, (error, results) => {
                if (error) {
                    reject(error);
                } else {
                    resolve(results);
                }
            });
        });
    }

    close() {
        this.connection.end();
    }
}

class AuthService {
    constructor(database) {
        this.database = database;
    }

    async login(username, password) {
        await this.database.connect();
        const query = 'SELECT password FROM users WHERE username = ?';
        const results = await this.database.query(query, [username]);
        if (results.length === 0) {
            console.log('Invalid username or password');
            this.database.close();
            return;
        }
        const hashedPassword = results[0].password;
        const match = await bcrypt.compare(password, hashedPassword);
        if (match) {
            console.log('Login successful');
        } else {
            console.log('Invalid username or password');
        }
        this.database.close();
    }
}

// Example usage:
const dbConfig = {
    host: 'localhost',
    user: 'root',
    password: 'password',
    database: 'testdb'
};

const database = new Database(dbConfig);
const authService = new AuthService(database);
authService.login('admin', 'password123');