import { useState, useEffect } from 'react';
import api from '../services/api';
import { useNavigate } from 'react-router-dom';

export default function Notes() {
  const [notes, setNotes] = useState([]);
  const [title, setTitle] = useState('');
  const [content, setContent] = useState('');
  const navigate = useNavigate();

  const fetchNotes = async () => {
    try {
      const res = await api.get('/note');
      setNotes(res.data);
    } catch {
      navigate('/login');
    }
  };

  const createNote = async () => {
    if (!title) return;
    await api.post('/note', { title, content, userId: 1 });
    setTitle('');
    setContent('');
    fetchNotes();
  };

  const deleteNote = async (id) => {
    await api.delete(`/note/${id}`);
    fetchNotes();
  };

  const logout = () => {
    localStorage.removeItem('token');
    navigate('/login');
  };

  useEffect(() => { fetchNotes(); }, []);

  return (
    <div style={styles.container}>
      <div style={styles.header}>
        <h2>My Notes</h2>
        <button style={styles.logout} onClick={logout}>Logout</button>
      </div>

      <div style={styles.form}>
        <input style={styles.input} placeholder="Title" value={title} onChange={e => setTitle(e.target.value)} />
        <input style={styles.input} placeholder="Content" value={content} onChange={e => setContent(e.target.value)} />
        <button style={styles.button} onClick={createNote}>Add Note</button>
      </div>

      <div style={styles.list}>
        {notes.map(note => (
          <div key={note.id} style={styles.note}>
            <div style={styles.noteInfo}>
              <span style={{ fontWeight: 'bold' }}>{note.title}</span>
              <span style={styles.content}>{note.content}</span>
            </div>
            <button style={styles.delete} onClick={() => deleteNote(note.id)}>✕</button>
          </div>
        ))}
      </div>
    </div>
  );
}

const styles = {
  container: { maxWidth: '600px', margin: '2rem auto', padding: '1rem' },
  header: { display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '1.5rem' },
  form: { display: 'flex', gap: '0.5rem', marginBottom: '1.5rem', flexWrap: 'wrap' },
  input: { flex: 1, padding: '0.6rem', borderRadius: '4px', border: '1px solid #ccc', fontSize: '1rem' },
  button: { padding: '0.6rem 1rem', background: '#4f46e5', color: 'white', border: 'none', borderRadius: '4px', cursor: 'pointer' },
  logout: { padding: '0.5rem 1rem', background: '#ef4444', color: 'white', border: 'none', borderRadius: '4px', cursor: 'pointer' },
  list: { display: 'flex', flexDirection: 'column', gap: '0.75rem' },
  note: { display: 'flex', justifyContent: 'space-between', alignItems: 'center', background: 'white', padding: '1rem', borderRadius: '8px', boxShadow: '0 1px 4px rgba(0,0,0,0.1)' },
  noteInfo: { display: 'flex', flexDirection: 'column', gap: '0.25rem' },
  content: { fontSize: '0.85rem', color: '#666' },
  delete: { padding: '0.4rem 0.7rem', background: '#ef4444', color: 'white', border: 'none', borderRadius: '4px', cursor: 'pointer' },
};
