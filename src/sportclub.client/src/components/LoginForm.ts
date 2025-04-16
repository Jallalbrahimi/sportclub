import { LitElement, html, css, unsafeCSS } from 'lit';
import { property } from 'lit/decorators.js';

export class LoginForm extends LitElement {

    // Disable shadow DOM to apply global styles
    createRenderRoot() {
        return this;
    }

    static styles = css`
    :host {
      display: block;
    }
  `;

    @property({ type: String }) email = '';
    @property({ type: String }) password = '';

    async login() {
        const response = await fetch('https://localhost:7043/api/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ email: this.email, password: this.password })
        });
        if (response.ok) {
            const data = await response.json();
            localStorage.setItem('token', data.token);
            alert('Login successful!');
        } else {
            alert('Login failed');
        }
    }

    render() {
        return html`
          <div class="card bg-base-100 w-96 shadow-sm">
            <div class="card-body">
              <h2 class="card-title justify-center">Login</h2>

              <!-- email -->
              <div>           
                <label class="input validator">
                  <svg class="h-[1em] opacity-50" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g stroke-linejoin="round" stroke-linecap="round" stroke-width="2.5" fill="none" stroke="currentColor"><rect width="20" height="16" x="2" y="4" rx="2"></rect><path d="m22 7-8.97 5.7a1.94 1.94 0 0 1-2.06 0L2 7"></path></g></svg>
                  <input type="email" placeholder="mail@site.com" required value=${this.email} @change="${(e) => this.email = e.target.value}" />
                </label>
                <div class="validator-hint hidden">Enter valid email address</div>
              </div>
              
              <!-- password -->
              <div>
               <label class="input validator">
                  <svg class="h-[1em] opacity-50" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g stroke-linejoin="round" stroke-linecap="round" stroke-width="2.5" fill="none" stroke="currentColor"><path d="M2.586 17.414A2 2 0 0 0 2 18.828V21a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-1a1 1 0 0 1 1-1h1a1 1 0 0 0 1-1v-1a1 1 0 0 1 1-1h.172a2 2 0 0 0 1.414-.586l.814-.814a6.5 6.5 0 1 0-4-4z"></path><circle cx="16.5" cy="7.5" r=".5" fill="currentColor"></circle></g></svg>
                  <input type="password" required value=${this.password} @change="${(e) => this.password = e.target.value}" placeholder="Password" minlength="8" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Must be more than 8 characters, including number, lowercase letter, uppercase letter" />
                </label>
                <p class="validator-hint hidden">
                  Must be more than 8 characters, including
                  <br/>At least one number
                  <br/>At least one lowercase letter
                  <br/>At least one uppercase letter
                </p>
              </div>

              <div class="card-actions justify-center">
                <button class="btn"  @click=${this.login}>Login</button>
              </div>
            </div>
          </div>

        `;
    }
}

customElements.define('login-form', LoginForm);
