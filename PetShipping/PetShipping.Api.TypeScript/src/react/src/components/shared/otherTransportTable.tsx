import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OtherTransportMapper from '../otherTransport/otherTransportMapper';
import OtherTransportViewModel from '../otherTransport/otherTransportViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface OtherTransportTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface OtherTransportTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<OtherTransportViewModel>;
}

export class  OtherTransportTableComponent extends React.Component<
OtherTransportTableComponentProps,
OtherTransportTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: OtherTransportViewModel) {
  this.props.history.push(ClientRoutes.OtherTransports + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: OtherTransportViewModel) {
   this.props.history.push(ClientRoutes.OtherTransports + '/' + row.id);
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
          let response = resp.data as Array<Api.OtherTransportClientResponseModel>;

          console.log(response);

          let mapper = new OtherTransportMapper();
          
          let otherTransports:Array<OtherTransportViewModel> = [];

          response.forEach(x =>
          {
              otherTransports.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: otherTransports,
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
                    Header: 'OtherTransports',
                    columns: [
					  {
                      Header: 'HandlerId',
                      accessor: 'handlerId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Handlers + '/' + props.original.handlerId); }}>
                          {String(
                            props.original.handlerIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'PipelineStepId',
                      accessor: 'pipelineStepId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.PipelineSteps + '/' + props.original.pipelineStepId); }}>
                          {String(
                            props.original.pipelineStepIdNavigation.toDisplay()
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
                              row.original as OtherTransportViewModel
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
                              row.original as OtherTransportViewModel
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
    <Hash>6f2d1ae9b5b2396910b9b23f06ca1e84</Hash>
</Codenesium>*/