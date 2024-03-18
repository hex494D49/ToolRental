
const app = window.app || (() => {

    const modules = ["tab", "select"];

    const init = () => {
        console.log("App is up and running!");
        modules.forEach((module) => {
            if (app[module] && typeof app[module].init === "function") {
                app[module].init();
            }
        });
        getData();
    }

    const getData = () => {

        fetch('api/tools')
            .then(response => response.json())
            .then(data => app.table.populate(data, "api/tools", "#tools"))
            .catch(error => console.error('Unable to get items.', error));

        //fetch('api/reservations')
        //    .then(response => response.json())
        //    .then(data => app.table.populate(data, "api/reservations", "#reservations"))
        //    .catch(error => console.error('Unable to get items.', error));

        fetch('api/reservations')
            .then(response => response.json())
            .then(data => console.log(data))
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

app.table = (function () {
    var table;
    var url;

    var deleteItem = function (itemId) {
        var confirmDelete = confirm("Are you sure you want to delete this item?");

        if (confirmDelete) {
            ajaxRequest(url + '/' + itemId, 'DELETE', null, function (data) {
                console.log('Delete successful:', data);
            }, function (error) {
                console.error('Error during elete:', error);
            });
        }
    };

    var editItem = function (itemId) {
        ajaxRequest(url + '/' + itemId, 'GET', null, function (data) {
            var form = document.querySelector('form[name="tool"]');
            form.method = 'PUT';
            form.action = 'api/tools/' + itemId;

            form.elements['name'].value = data.name;
            form.elements['price'].value = data.pricePerHour;
        }, function (error) {
            console.error('Error during edit:', error);
        });
    };

    var addItem = function () {
        var tbody = table.tBodies[0];
        var firstRow = tbody.rows[0];
        var newRow = firstRow.cloneNode(true);

        Array.from(newRow.cells).forEach(function (cell) {
            if (cell.querySelector('input')) {
                cell.querySelector('input').value = '';
            }
        });

        tbody.appendChild(newRow);
    };

    var header = function (keys) {
        var thead = table.createTHead();
        var row = thead.insertRow();

        keys.forEach(function (key, index) {
            var th = document.createElement('th');
            if (index === 0) {
                var add = document.createElement('a');
                add.href = '#';
                add.textContent = 'Add new';
                add.addEventListener('click', function () {
                    addItem();
                });
                th.appendChild(add);
            } else {
                th.textContent = key;
            }
            row.appendChild(th);
        });
    };

    var body = function (data) {
        var tbody = table.createTBody();

        data.forEach(function (item, index) {
            var row = tbody.insertRow();

            Object.keys(item).forEach(function (key, innerIndex) {
                var cell = row.insertCell();

                if (innerIndex === 0) {
                    var edit = document.createElement('A');
                    edit.href = "#";
                    edit.textContent = "Edit";

                    edit.addEventListener('click', function () {
                        editItem(item.id);
                    });

                    var remove = document.createElement('A');
                    remove.href = "#";
                    remove.textContent = "Delete";

                    remove.addEventListener('click', function () {
                        deleteItem(item.id);
                    });

                    cell.appendChild(edit);
                    cell.appendChild(document.createTextNode(" | "));
                    cell.appendChild(remove);
                } else {
                    cell.textContent = item[key];
                }
            });
        });
    };

    var footer = function (pager) {
        var tfoot = table.createTFoot();
        var row = tfoot.insertRow();
        var cell = row.insertCell();
        cell.colSpan = Object.keys(pager).length;

        if (pager) {
            buildPager(cell, pager, url);
        } else {
            console.warn("No pager data found.");
        }
    };

    var populate = function (payload, endpoint, target) {
        table = document.createElement('TABLE');
        url = endpoint;

        if ('data' in payload && Array.isArray(payload.data) && payload.data.length > 0) {
            var keys = Object.keys(payload.data[0]);
            header(keys);
            body(payload.data);
            footer(payload.pager);
        } else {
            console.error("Invalid payload data.");
            return;
        }

        document.querySelector(target).appendChild(table);
    };

    return {
        populate: populate
    };
})();


var buildPager = function (cell, pager, url) {
    var ul = document.createElement('ul');
    ul.classList.add('pager');

    var currentPage = pager.current;
    var totalPages = pager.total;
    var pagesBefore = 2;
    var pagesAfter = 2;

    for (var i = Math.max(1, currentPage - pagesBefore); i <= Math.min(totalPages, currentPage + pagesAfter); i++) {
        var li = document.createElement('li');
        li.classList.toggle('active', i === currentPage);

        if (i !== currentPage) {
            var link = document.createElement('a');
            link.href = url + '?page=' + i;
            link.textContent = i;
            li.appendChild(link);
        } else {
            li.textContent = i;
        }

        ul.appendChild(li);
    }

    cell.appendChild(ul);
};

app.select = (function () {
    let select,
        items,
        current = previous = -1;

    var init = function () {
        document.addEventListener('input', function (event) {
            if (event.target.matches('input[name$="query"]')) {
                select = event.target.parentNode;
                var value = event.target.value.trim();
                console.log("Value: " + value);
                fetchSuggestions(value);
            }
        });

        document.addEventListener('keydown', (event) => {
            if (event.target.matches('input[name$="query"]')) {
                ul = event.target.parentNode.querySelector("ul");
                items = ul ? ul.querySelectorAll("li:not(.hidden)") : [];
                let length = items.length;

                if (event.key === "ArrowDown") {
                    current = (current < length - 1) ? current + 1 : 0;
                    highlight(current, ul);
                } else if (event.key === "ArrowUp") {
                    current = (current > 0) ? current - 1 : length - 1;
                    highlight(current, ul);
                } else if (event.key === "Enter") {
                    event.preventDefault();
                    if (current > -1 && items[current]) {
                        items[current].click();
                    }
                }
            }
        });

        document.addEventListener('click', (event) => {
            // Check if the clicked element is an 'li' inside the '.select' class
            if (event.target.matches('.select li')) {
                let li = event.target;
                let inputQuery = select.querySelector('input[name$="query"]');
                let hiddenInput = select.querySelector('input[type="hidden"]');

                inputQuery.value = li.innerText;
                hiddenInput.value = li.getAttribute("data-id");

                console.log('Selected ID:', hiddenInput.value);
                console.log('Selected Text:', inputQuery.value);

                current = previous = -1;
            }
        });

        var highlight = function (index, ul) {
            var items = ul.querySelectorAll("li:not(.hidden)");
            if (previous > -1 && items[previous]) {
                items[previous].classList.remove("active");
            }
            if (items[index]) {
                items[index].classList.add("active");
                previous = index;
            }
        };

        var fetchSuggestions = function (value) {
            fetch('api/tools?Name=' + value)
                .then(response => response.json())
                .then(data => {
                    //console.log("oHoohOo -> " + JSON.stringify(data));
                    populateSuggestions(data['data']);
                })
                .catch(error => console.error('Error fetching suggestions:', error));
        };

        var populateSuggestions = function (data) {
            var ul = select.querySelector('ul');
            if (!ul) {
                var ul = document.createElement('ul');
                select.appendChild(ul);
            }

            ul.innerHTML = '';

            console.log("ToOo -> " + JSON.stringify(data));

            if (data && data.length > 0) {
                data.forEach(item => {
                    console.log(item);
                    var li = document.createElement('li');
                    li.textContent = item.name;
                    li.setAttribute('data-id', item.id);
                    ul.appendChild(li);
                });
            }
        };
    };

    return {
        init: init
    };

})();

var ajaxRequest = function (url, method, data, successCallback, errorCallback) {
    fetch(url, {
        method: method,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(successCallback)
        .catch(errorCallback);
};

var calculateDatetimeDifference = function(startDatetime, endDatetime) {
    if (endDatetime < startDatetime) {
        console.error("Error: endDatetime should be greater than or equal to startDatetime");
        return null;
    }

    const millisecondsDiff = Math.abs(endDatetime - startDatetime);

    const seconds = Math.floor(millisecondsDiff / 1000);
    const minutes = Math.floor(seconds / 60);
    const hours = Math.floor(minutes / 60);
    const days = Math.floor(hours / 24);
    const years = Math.floor(days / 365.25);

    return {
        "years": years,
        "days": days % 365,
        "hours": hours % 24,
        "minutes": minutes % 60,
        "seconds": seconds % 60
    };
}

window.onload = app.init();
