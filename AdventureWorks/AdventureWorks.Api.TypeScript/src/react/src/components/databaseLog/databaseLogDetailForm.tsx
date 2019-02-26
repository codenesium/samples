import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DatabaseLogMapper from './databaseLogMapper';
import DatabaseLogViewModel from './databaseLogViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface DatabaseLogDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DatabaseLogDetailComponentState {
  model?: DatabaseLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class DatabaseLogDetailComponent extends React.Component<
DatabaseLogDetailComponentProps,
DatabaseLogDetailComponentState
> {
  state = {
    model: new DatabaseLogViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.DatabaseLogs + '/edit/' + this.state.model!.databaseLogID);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.DatabaseLogs +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.DatabaseLogClientResponseModel;

          console.log(response);

          let mapper = new DatabaseLogMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
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
    } else if (this.state.loaded) {
      return (
        <div>
		<Button 
			style={{'float':'right'}}
			type="primary" 
			onClick={(e:any) => {
				this.handleEditClick(e)
				}}
			>
             <i className="fas fa-edit" />
		  </Button>
		  <div>
									 <div>
							<h3>DatabaseLogID</h3>
							<p>{String(this.state.model!.databaseLogID)}</p>
						 </div>
					   						 <div>
							<h3>DatabaseUser</h3>
							<p>{String(this.state.model!.databaseUser)}</p>
						 </div>
					   						 <div>
							<h3>PostTime</h3>
							<p>{String(this.state.model!.postTime)}</p>
						 </div>
					   						 <div>
							<h3>Schema</h3>
							<p>{String(this.state.model!.schema)}</p>
						 </div>
					   						 <div>
							<h3>TSQL</h3>
							<p>{String(this.state.model!.tsql)}</p>
						 </div>
					   						 <div>
							<h3>XmlEvent</h3>
							<p>{String(this.state.model!.xmlEvent)}</p>
						 </div>
					   		  </div>
          {message}


        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedDatabaseLogDetailComponent = Form.create({ name: 'DatabaseLog Detail' })(
  DatabaseLogDetailComponent
);

/*<Codenesium>
    <Hash>4209898e793d2bddc686d1e3231de0e2</Hash>
</Codenesium>*/