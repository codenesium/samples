import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CustomerCommunicationMapper from './customerCommunicationMapper';
import CustomerCommunicationViewModel from './customerCommunicationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface CustomerCommunicationDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CustomerCommunicationDetailComponentState {
  model?: CustomerCommunicationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CustomerCommunicationDetailComponent extends React.Component<
  CustomerCommunicationDetailComponentProps,
  CustomerCommunicationDetailComponentState
> {
  state = {
    model: new CustomerCommunicationViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.CustomerCommunications + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.CustomerCommunications +
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
          let response = resp.data as Api.CustomerCommunicationClientResponseModel;

          console.log(response);

          let mapper = new CustomerCommunicationMapper();

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
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div style={{ marginBottom: '10px' }}>
              <h3>customerId</h3>
              <p>
                {String(this.state.model!.customerIdNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>dateCreated</h3>
              <p>{String(this.state.model!.dateCreated)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>employeeId</h3>
              <p>
                {String(this.state.model!.employeeIdNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div>
              <h3>notes</h3>
              <p>{String(this.state.model!.note)}</p>
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

export const WrappedCustomerCommunicationDetailComponent = Form.create({
  name: 'CustomerCommunication Detail',
})(CustomerCommunicationDetailComponent);


/*<Codenesium>
    <Hash>49ba332699b87ca230277376326a1c5c</Hash>
</Codenesium>*/