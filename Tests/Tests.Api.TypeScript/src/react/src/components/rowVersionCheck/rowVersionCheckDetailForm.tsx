import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import RowVersionCheckMapper from './rowVersionCheckMapper';
import RowVersionCheckViewModel from './rowVersionCheckViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface RowVersionCheckDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface RowVersionCheckDetailComponentState {
  model?: RowVersionCheckViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class RowVersionCheckDetailComponent extends React.Component<
RowVersionCheckDetailComponentProps,
RowVersionCheckDetailComponentState
> {
  state = {
    model: new RowVersionCheckViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.RowVersionChecks + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.RowVersionChecks +
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
          let response = resp.data as Api.RowVersionCheckClientResponseModel;

          console.log(response);

          let mapper = new RowVersionCheckMapper();

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
							<h3>Id</h3>
							<p>{String(this.state.model!.id)}</p>
						 </div>
					   						 <div>
							<h3>Name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   						 <div>
							<h3>RowVersion</h3>
							<p>{String(this.state.model!.rowVersion)}</p>
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

export const WrappedRowVersionCheckDetailComponent = Form.create({ name: 'RowVersionCheck Detail' })(
  RowVersionCheckDetailComponent
);

/*<Codenesium>
    <Hash>a9eece4717640defc22aab3ff1f912d1</Hash>
</Codenesium>*/