import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import NoteMapper from '../note/noteMapper';
import NoteViewModel from '../note/noteViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface NoteTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface NoteTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<NoteViewModel>;
}

export class  NoteTableComponent extends React.Component<
NoteTableComponentProps,
NoteTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: NoteViewModel) {
  this.props.history.push(ClientRoutes.Notes + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: NoteViewModel) {
   this.props.history.push(ClientRoutes.Notes + '/' + row.id);
 }

  componentDidMount() {
	this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.NoteClientResponseModel>;

          console.log(response);

          let mapper = new NoteMapper();
          
          let notes:Array<NoteViewModel> = [];

          response.forEach(x =>
          {
              notes.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: notes,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
	else if (this.state.errorOccurred) {
	  return <Alert message={this.state.errorMessage} type='error' />;
	}
	 else if (this.state.loaded) {
      return (
	  <div>
		{message}
         <ReactTable 
                data={this.state.filteredRecords}
				defaultPageSize={10}
                columns={[{
                    Header: 'Notes',
                    columns: [
					  {
                      Header: 'CallId',
                      accessor: 'callId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Calls + '/' + props.original.callId); }}>
                          {String(
                            props.original.callIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'DateCreated',
                      accessor: 'dateCreated',
                      Cell: (props) => {
                      return <span>{String(props.original.dateCreated)}</span>;
                      }           
                    },  {
                      Header: 'NoteText',
                      accessor: 'noteText',
                      Cell: (props) => {
                      return <span>{String(props.original.noteText)}</span>;
                      }           
                    },  {
                      Header: 'OfficerId',
                      accessor: 'officerId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Officers + '/' + props.original.officerId); }}>
                          {String(
                            props.original.officerIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },
                    {
                        Header: 'Actions',
					    minWidth:150,
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as NoteViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleEditClick(
                              e,
                              row.original as NoteViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        </div>)
                    }],
                    
                  }]} />
			</div>
      );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>3f1ae0cef90e8b5f3bb6027a7dd96a47</Hash>
</Codenesium>*/