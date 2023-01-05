import { Component, OnInit } from '@angular/core';
import Chart from 'chart.js';

// core components
import {
  chartOptions,
  dashboardChart,
  parseOptions,
} from "../../variables/charts";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  
  public salesChart;
  public clicked: boolean = true;
  public clicked1: boolean = false;
  public selectedChartTag: any;

  ngOnInit() {
    parseOptions(Chart, chartOptions());

    var chartSales = document.getElementById('chart-sales');

    this.salesChart = new Chart(chartSales, {
			type: 'line',
			options: dashboardChart.options,
			data: dashboardChart.data,
		});

    this.updateOptions('Errors');
  }

  public updateOptions(tag) {
    this.selectedChartTag = tag;
    // dashboardChart.data.datasets[0].data = this.data;
    this.salesChart.update();
  }
}
