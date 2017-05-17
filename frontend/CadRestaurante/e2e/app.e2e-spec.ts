import { CadRestaurantePage } from './app.po';

describe('cad-restaurante App', () => {
  let page: CadRestaurantePage;

  beforeEach(() => {
    page = new CadRestaurantePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
