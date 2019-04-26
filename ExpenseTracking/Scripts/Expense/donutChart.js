var expenseNames = $(".expenseName").map(function () {
    return this.innerText;
}).get();

var expenseValues = $(".expenseValue").map(function () {
    return this.innerText;
}).get();

function dataToChart(data) {
    let temp = [];
    for (let i = 0; i < data.length; i++) {
        temp.push(getRandomColor());
    }
    return {
        type: 'pie',
        data: {
            datasets: [{
                data: expenseValues.map(x => parseFloat(x.slice(1))),
                backgroundColor: temp
            }],
            labels: expenseNames
        },
        options: {
            responsive: true
        }
    };
}
function getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}
window.onload = function () {
    var ctx = document.getElementById("pieChart").getContext("2d");
    window.myPie = new Chart(ctx, dataToChart(expenseNames));
};