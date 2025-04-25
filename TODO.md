# TODO tasks

- [ ] Frontend Organization: Consolidate frontend files (create_page, recipes_page, start_page) into a single 'public' or 'client' directory to simplify static file serving and project structure.
- [ ] Configuration: Use environment variables (e.g., via a .env file and the dotenv package) for configurable values like the server port and database file path instead of hardcoding them.
- [ ] Error Handling & Logging: Enhance error handling in server.js by logging errors with more details and possibly using a logging library like Winston or Morgan for better monitoring.
- [ ] Async/Await: The sqlite3 library uses callbacks; consider using a promise-based wrapper or converting callbacks to promises for cleaner asynchronous code.
- [ ] Input Validation: Add validation for incoming POST request data to ensure data integrity and prevent malformed inputs.
- [ ] Documentation: Add a README.md file with project overview, setup instructions, and usage details.
- [ ] Database Management: If your database schema grows, consider adding migration scripts or using a migration tool.
- [ ] Security: Review CORS settings and restrict origins if needed for production.
- [ ] Frontend Improvements: If the frontend grows complex, consider using a frontend framework or bundler for better maintainability.
- [ ] Resolve error on localhost:3000
- [ ] General code fixes
- [ ] Use correct structures in HTML
- [ ] Merge styles.css into one file
- [ ] Add images to /static/images/
- [ ] Write README file

## Instructions for restructuring and moving files:

- Create a new folder named `public` at the root of the project.
- Move the folders `create_page`, `recipes_page`, and `start_page` into the `public` folder.
- Update `server.js` to serve static files from the `public` folder instead of the current setup.
- Create a `.env` file at the root for environment variables like PORT and DB_PATH.
- Update `server.js` to read configuration from environment variables.
- Add validation middleware for POST requests in `server.js`.
- Add logging middleware using a library like Morgan.
- Consider refactoring sqlite3 usage to use promises or async/await.
- Add migration scripts folder if needed (e.g., `migrations/`).
- Add a README.md file with project setup and usage instructions.
- Consolidate CSS files into one main stylesheet in the public folder.
- Create a folder `public/static/images/` and move all images there.

## Empty folders and files to create now:

- Create folder: `public/`
- Create folder: `public/static/`
- Create folder: `public/static/images/`
- Create empty `.env` file at root
