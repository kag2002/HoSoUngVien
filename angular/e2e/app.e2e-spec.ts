import { HoSoUngVienTemplatePage } from './app.po';

describe('HoSoUngVien App', function() {
  let page: HoSoUngVienTemplatePage;

  beforeEach(() => {
    page = new HoSoUngVienTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
