
const app = window.app || (() => {

    const modules = ["tab"];

    const init = () => {
        console.log("App is up and running!");
        modules.forEach((module) => {
            if (app[module] && typeof app[module].init === "function") {
                app[module].init();
            }
        });
        render();
    }

    const render = () => {

        fetch('tools')
            .then(response => response.json())
            .then(data => app.table.populate(data, "#tools"))
            .catch(error => console.error('Unable to get items.', error));

        fetch('reservations')
            .then(response => response.json())
            .then(data => app.table.populate(data, "#reservations"))
            .catch(error => console.error('Unable to get items.', error));

    }

    return {
        init
    }

})();

app.tab = (() => {

    const init = () => {
        console.log("Tab is up and running!");

        document.addEventListener('click', (event) => {
            if (event.target.matches('.tab > ul > li')) {
                swap(event.target);
            }
        });
    }

    const swap = (target) => {

        let
            div = target.parentNode.parentNode,
            ul = target.parentNode,
            lis = ul.children;

        for (var i = 0; i < lis.length; i++) {
            if (lis[i] == target) {
                lis[i].classList.add("active");
                div.children[i + 1].classList.add("active");
            } else {
                lis[i].classList.remove("active");
                div.children[i + 1].classList.remove("active");
            }
        }
    }

    return {
        init
    }

})();

app.table = (() => {

    const populate = (data, target) => {

        // Assuming data is an array of objects, and the keys represent table column headers
        const keys = Object.keys(data[0]);

        // Create table element
        const table = document.createElement('table');

        // Create table header row
        const headerRow = table.insertRow();
        keys.forEach(key => {
            const th = document.createElement('th');
            th.textContent = key;
            headerRow.appendChild(th);
        });
        // Add additional headers for Edit and Delete
        headerRow.insertCell().textContent = 'Edit';
        headerRow.insertCell().textContent = 'Delete';

        data.forEach(item => {
            const row = table.insertRow();
            keys.forEach(key => {
                const cell = row.insertCell();
                cell.textContent = item[key];
            });

            // Add Edit button/link
            const editCell = row.insertCell();
            const editButton = document.createElement('button');
            editButton.textContent = 'Edit';
            editButton.addEventListener('click', () => editItem(item));
            editCell.appendChild(editButton);

            // Add Delete button/link
            const deleteCell = row.insertCell();
            const deleteButton = document.createElement('button');
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', () => deleteItem(item.id)); // Assuming 'id' is the unique identifier
            deleteCell.appendChild(deleteButton);
        });

        // Append the table to the document body or any other HTML element
        document.querySelector(target).appendChild(table);

    }

    return {
        populate
    }

}) ();


window.onload = app.init();
