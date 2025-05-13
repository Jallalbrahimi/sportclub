import { fail, redirect } from '@sveltejs/kit';

export const actions = {
	login: async (event) => {
		// Get the form data
		const data = await event.request.formData();
		const email = data.get('email');
		const password = data.get('password');

		const res = await event.fetch('/api/login', {
			method: 'POST',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify({ email, password }),
			credentials: 'include' // important if using cookies
		});

		if (res.ok) {
			// Redirect to dashboard or home page
			return redirect(302, '/');
			//goto('/dashboard');
		} else {
			return fail(400, { message: 'Login failed' });
		}
	}
};
