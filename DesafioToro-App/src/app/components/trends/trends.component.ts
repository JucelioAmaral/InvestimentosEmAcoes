import { Component, OnInit } from '@angular/core';
import { Trend } from 'src/app/utils/trend';
import { TrendService} from 'src/app/services/trend.service';

@Component({
  selector: 'app-trends',
  templateUrl: './trends.component.html',
  styleUrls: ['./trends.component.css'],
})
export class TrendsComponent implements OnInit {
  trends: Trend[] = [];

  constructor(private trendService: TrendService) {}

  ngOnInit(): void {
    this.getTrends();
  }

  public getTrends() : void {
    this.trendService.getTrends().subscribe((trend: any) => {
      this.trends = trend;
    });
  }
}
