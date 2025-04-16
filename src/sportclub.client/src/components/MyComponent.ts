import { LitElement, html, css } from 'lit';
import { customElement, property } from 'lit/decorators.js';

@customElement('my-component')
export class MyComponent extends LitElement {
    static styles = css`
    p {
      color: blue;
    }
  `;

    @property({ type: String }) name = 'RunClub';

    render() {
        return html`<p>Welcome to ${this.name}!</p>`;
    }
}
