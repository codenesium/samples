import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import MessengerMapper from '../messenger/messengerMapper';
import MessengerViewModel from '../messenger/messengerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface MessengerTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface MessengerTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<MessengerViewModel>;
}

export class  MessengerTableComponent extends React.Component<
MessengerTableComponentProps,
MessengerTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: MessengerViewModel) {
  this.props.history.push(ClientRoutes.Messengers + '/edit/' + row.id);
}

handleDetailClick(e:any, row: MessengerViewModel) {
  this.props.history.push(ClientRoutes.Messengers + '/' + row.id);
}

  componentDidMount() {
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
          let response = resp.data as Array<Api.MessengerClientResponseModel>;

          console.log(response);

          let mapper = new MessengerMapper();
          
          let messengers:Array<MessengerViewModel> = [];

          response.forEach(x =>
          {
              messengers.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: messengers,
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
                    Header: 'Messengers',
                    columns: [
					  {
                      Header: 'Date',
                      accessor: 'date',
                      Cell: (props) => {
                      return <span>{String(props.original.date)}</span>;
                      }           
                    },  {
                      Header: 'From_user_id',
                      accessor: 'fromUserId',
                      Cell: (props) => {
                      return <span>{String(props.original.fromUserId)}</span>;
                      }           
                    },  {
                      Header: 'Message_id',
                      accessor: 'messageId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Messages + '/' + props.original.messageId); }}>
                          {String(
                            props.original.messageIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Time',
                      accessor: 'time',
                      Cell: (props) => {
                      return <span>{String(props.original.time)}</span>;
                      }           
                    },  {
                      Header: 'To_user_id',
                      accessor: 'toUserId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Users + '/' + props.original.toUserId); }}>
                          {String(
                            props.original.toUserIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'User_id',
                      accessor: 'userId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Users + '/' + props.original.userId); }}>
                          {String(
                            props.original.userIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as MessengerViewModel
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
                              row.original as MessengerViewModel
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
    <Hash>171f18bd04a174b09dbbec1031ba1ed8</Hash>
</Codenesium>*/