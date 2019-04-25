let pieData = [
    {
        value: 121.45,
        label: "groceries"
    },
    {
        value: 70,
        label: "shoes"
    }, {
        value: 9.55,
        label: "food"
    }
];

function dataToChart(data) {
    let temp = []
    for (let i = 0; i < data.length; i++) {
        temp.push(getRandomColor())
    }
    return {
        type: 'pie',
        data: {
            datasets: [{
                data: data.map(x => x.value),
                backgroundColor: temp,
            }],
            labels: data.map(x => x.label)
        },
        options: {
            responsive: true
        }
    }
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
    var ctx = document.getElementById("donutChart").getContext("2d");
    window.myPie = new Chart(ctx, dataToChart(pieData));
};